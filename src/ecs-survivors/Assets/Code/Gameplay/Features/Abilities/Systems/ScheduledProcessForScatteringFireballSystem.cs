using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Common.Geometry;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class ScheduledProcessForScatteringFireballSystem : IExecuteSystem
  {
    private readonly IArmamentsFactory _armamentsFactory;
    private readonly IStaticDataService _staticDataService;
    private readonly IGeometryService _geometryService;

    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _armaments;
    private readonly List<GameEntity> _buffer = new(64);

    public ScheduledProcessForScatteringFireballSystem(
      GameContext game, 
      IArmamentsFactory armamentsFactory,
      IStaticDataService staticDataService,
      IGeometryService geometryService)
    {
      _armamentsFactory = armamentsFactory;
      _staticDataService = staticDataService;
      _geometryService = geometryService;

      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ScheduledToProcessByArmaments,
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));
      
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.ScatteringFireballArmament,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity enemy in _enemies)
        foreach (GameEntity armament in _armaments.GetEntities(_buffer))
        {
          if (enemy.ScheduledToProcessByArmaments.Contains(armament.Id))
          {
            int projectileAmount = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireball, 1).ProjectileAmount;
            Vector2[] directions = _geometryService.GetRadialDirections(projectileAmount).ToArray();
            
            for (int i = 0; i < projectileAmount; i++)
            {
              _armamentsFactory.CreateChildFireball(1, enemy.WorldPosition)
                .ReplaceDirection(directions[i])
                .With(x => x.isMoving = true);
            }
            
            enemy.ProcessedByArmaments.Add(armament.Id);
            enemy.ScheduledToProcessByArmaments.Remove(armament.Id);
          }
        }
    }
  }
}