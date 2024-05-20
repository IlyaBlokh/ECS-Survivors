using System.Collections.Generic;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
  public class SpeedUpAuraAbilitySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _abilities;
    private readonly IArmamentFactory _armamentFactory;
    private readonly IGroup<GameEntity> _heroes;
    private readonly List<GameEntity> _buffer = new(1);

    public SpeedUpAuraAbilitySystem(GameContext game, IArmamentFactory armamentFactory)
    {
      _armamentFactory = armamentFactory;
      
      _abilities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.SpeedUpAuraAbility)
        .NoneOf(GameMatcher.Active));
      
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero, 
          GameMatcher.Id));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes) 
        foreach (GameEntity ability in _abilities.GetEntities(_buffer))
        {
          _armamentFactory.CreateSpeedUpEffectAura(AbilityId.SpeedUpAura, hero.Id, 1);
          ability.isActive = true;
        }
    }
  }
}