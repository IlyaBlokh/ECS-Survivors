using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Common.Geometry;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class ShovelRadialStrikeAbilitySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _abilities;
    private readonly IStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentsFactory;
    private readonly IGeometryService _geometryService;

    private readonly IGroup<GameEntity> _heroes;
    private readonly List<GameEntity> _buffer = new(1);

    public ShovelRadialStrikeAbilitySystem(
      GameContext game,
      IStaticDataService staticDataService,
      IArmamentFactory armamentsFactory,
      IGeometryService geometryService)
    {
      _armamentsFactory = armamentsFactory;
      _staticDataService = staticDataService;
      _geometryService = geometryService;

      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ShovelRadialStrikeAbility, 
          GameMatcher.CooldownUp));

      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
        foreach (GameEntity hero in _heroes)
        {
          int projectileAmount = _staticDataService.GetAbilityLevel(AbilityId.ShovelRadialStrike, 1).ProjectileAmount;
          Vector2[] directions = _geometryService.GetRadialDirections(projectileAmount).ToArray();
          
          for (int i = 0; i < projectileAmount; i++)
          {
            _armamentsFactory.CreateShovelBolt(1, hero.WorldPosition)
              .ReplaceDirection(directions[i])
              .With(x => x.isMoving = true);
          }

          ability
            .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.ShovelRadialStrike, 1).Cooldown);
        }
    }
  }
}