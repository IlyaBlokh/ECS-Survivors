﻿using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
  public class SpeedUpAuraAbilitySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _abilities;
    private readonly IArmamentFactory _armamentFactory;
    
    private readonly List<GameEntity> _buffer = new(32);

    public SpeedUpAuraAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
    {
      _armamentFactory = armamentFactory;

      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.SpeedUpAuraAbility,
          GameMatcher.ProducerId)
        .NoneOf(GameMatcher.Active));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      {
        _armamentFactory.CreateSpeedUpEffectAura(AbilityId.SpeedUpAura, ability.ProducerId, 1);
        ability.isActive = true;
      }
    }
  }
}