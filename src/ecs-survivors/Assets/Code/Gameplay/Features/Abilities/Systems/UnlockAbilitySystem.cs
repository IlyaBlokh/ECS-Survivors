using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class UnlockAbilitySystem : IExecuteSystem
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IAbilityFactory _abilityFactory;
    private readonly IGroup<GameEntity> _heroes;

    public UnlockAbilitySystem(GameContext game, IStaticDataService staticDataService, IAbilityFactory abilityFactory)
    {
      _abilityFactory = abilityFactory;
      _staticDataService = staticDataService;
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.KillScore,
          GameMatcher.Abilities));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      {
        List<AbilityId> availableAbilities = _staticDataService.GetAvailableAbilities(hero.KillScore);
        foreach (AbilityId abilityId in availableAbilities)
        {
          if (hero.Abilities.Contains(abilityId))
            continue;

          switch (abilityId)
          {
            case AbilityId.VegetableBolt:
              _abilityFactory.CreateVegetableBoltAbility(level: 1);
              break;
            case AbilityId.ShovelRadialStrike:
              _abilityFactory.CreateShovelRadialStrikeAbility(level: 1);
              break;
            case AbilityId.BouncingBeer:
              _abilityFactory.CreateBouncingBeerAbility(level: 1);
              break;
            case AbilityId.ScatteringFireball:
              _abilityFactory.CreateScatteringFireballAbility(level: 1);
              break;
            case AbilityId.Unknown:
              throw new Exception("Tried to add unknown ability");
          }
          hero.Abilities.Add(abilityId);
        }
      }
    }
  }
}