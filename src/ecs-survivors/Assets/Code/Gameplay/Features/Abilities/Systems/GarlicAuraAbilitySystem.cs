using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class GarlicAuraAbilitySystem : IExecuteSystem
  {
    private readonly List<GameEntity> _buffer = new(1);
    
    private readonly IArmamentFactory _armamentFactory;
    private readonly IGroup<GameEntity> _abilities;
    private readonly IGroup<GameEntity> _heroes;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    public GarlicAuraAbilitySystem(GameContext game, IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService)
    {
      _armamentFactory = armamentFactory;
      _abilityUpgradeService = abilityUpgradeService;
      _abilities = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.GarlicAuraAbility)
        .NoneOf(GameMatcher.Active));

      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Hero));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
      foreach (GameEntity hero in _heroes)
      {
        int level = _abilityUpgradeService.GetAbilityLevel(AbilityId.GarlicAura);
        _armamentFactory.CreateGarlicEffectAura(AbilityId.GarlicAura, hero.Id, level);

        ability.isActive = true;
      }
    }
  }
}