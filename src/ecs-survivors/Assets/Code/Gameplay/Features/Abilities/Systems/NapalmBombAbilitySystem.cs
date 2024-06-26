﻿using System.Collections.Generic;
using Code.Common.Extensions;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class NapalmBombAbilitySystem : IExecuteSystem
  {
    private const float MaxTargetDistance = 10f;
    
    private readonly IStaticDataService _staticDataService;
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;
    private readonly IRandomService _random;
    private readonly List<GameEntity> _buffer = new(1);

    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;

    public NapalmBombAbilitySystem(
      GameContext game,
      IStaticDataService staticDataService,
      IArmamentFactory armamentFactory,
      IAbilityUpgradeService abilityUpgradeService,
      IRandomService random)
    {
      _random = random;
      _abilityUpgradeService = abilityUpgradeService;
      _staticDataService = staticDataService;
      _armamentFactory = armamentFactory;

      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.NapalmBombAbility,
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
          int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.NapalmBomb);
          
          Vector2 randomDestination = _random.RandomInRadius(MaxTargetDistance);
          
          _armamentFactory
            .CreateNapalmBomb(level, hero.WorldPosition)
            .AddProducerId(hero.Id)
            .AddTargetDestination(randomDestination)
            .ReplaceDirection((randomDestination.ToVector3() - hero.WorldPosition).normalized)
            .With(x => x.isMoving = true);
        
          ability
            .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.NapalmBomb, level).Cooldown);
        }
    }
    
  }
}