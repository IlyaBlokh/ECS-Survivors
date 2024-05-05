using System.Collections.Generic;
using Code.Common.Extensions;
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
    private readonly IArmamentsFactory _armamentsFactory;
    private readonly List<GameEntity> _buffer = new(1);
    private readonly IGroup<GameEntity> _heroes;

    public ShovelRadialStrikeAbilitySystem(GameContext game, IStaticDataService staticDataService, IArmamentsFactory armamentsFactory)
    {
      _armamentsFactory = armamentsFactory;
      _staticDataService = staticDataService;
      
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
          float angleBetween = 2 * Mathf.PI / projectileAmount;
          for (int i = 0; i < projectileAmount; i++)
          {
            float x = Mathf.Cos(i * angleBetween);
            float y = Mathf.Sin(i * angleBetween);
            Vector2 startDirection = new Vector2(x, y).normalized;
            
            _armamentsFactory.CreateShovelBolt(1, hero.WorldPosition)
              .ReplaceDirection(startDirection)
              .With(x => x.isMoving = true);
          }

          ability
            .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.ShovelRadialStrike, 1).Cooldown);
        }
    }
  }
}