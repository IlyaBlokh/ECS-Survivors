using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Random;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.Abilities.Upgrade
{
  public class AbilityUpgradeService : IAbilityUpgradeService
  {
    private const int MinRepeatedAbilitiesToOffer = 1;
    private const int MaxCardsToOffer = 2;

    private readonly Dictionary<AbilityId, int> _currentAbilities;
    private readonly List<AbilityId> _unavailableAbilities;
    private readonly IRandomService _random;
    private readonly IAbilityFactory _abilityFactory;
    private readonly IStaticDataService _staticDataService;

    public AbilityUpgradeService(IRandomService randomService, IAbilityFactory abilityFactory, IStaticDataService staticDataService)
    {
      _currentAbilities = new Dictionary<AbilityId, int>();
      _unavailableAbilities = new List<AbilityId>();
      _random = randomService;
      _abilityFactory = abilityFactory;
      _staticDataService = staticDataService;
      InitializeUnavailableAbilities(staticDataService);
    }

    public int GetAbilityLevel(AbilityId abilityId) => 
      _currentAbilities.TryGetValue(abilityId, out int level) 
        ? level 
        : 0;

    public void InitializeAbility(AbilityId ability)
    {
      if (!_currentAbilities.TryAdd(ability, 1))
        throw new Exception($"Ability {ability} is already initialized");

      switch (ability)
      {
        case AbilityId.VegetableBolt:
          _abilityFactory.CreateVegetableBoltAbility(level: 1);
          break;
        case AbilityId.GarlicAura:
          _abilityFactory.CreateGarlicAuraAbility();
          break;
        case AbilityId.OrbitingMushroom:
          _abilityFactory.CreateOrbitingMushroomAbility(level: 1);
          break;        
        case AbilityId.NapalmBomb:
          _abilityFactory.CreateNapalmBombAbility(level: 1);
          break;
        default:
          throw new Exception($"Ability {ability} is not defined");
      }
    }

    public void UpgradeAbility(AbilityId ability)
    {
      if (_currentAbilities.ContainsKey(ability))
        _currentAbilities[ability]++;
      else
        InitializeAbility(ability);
    }

    private void InitializeUnavailableAbilities(IStaticDataService staticDataService)
    {
      foreach (AbilityId abilityId in Enum.GetValues(typeof(AbilityId)))
      {
        if (abilityId == AbilityId.Unknown)
          continue;
        
        if (!staticDataService.GetAbilityConfig(abilityId).AllowedOwners.Contains(OwnerType.Hero))
          _unavailableAbilities.Add(abilityId);
      }
    }
    
    public List<AbilityUpgradeOption> GetUpgradeOptions()
    {
      int repeatedAbilitiesToReturnCount = MinRepeatedAbilitiesToOffer + _random.Range(0, Math.Min(_currentAbilities.Count, MaxCardsToOffer));
      int newAbilitiesToReturnCount = Math.Min(MaxCardsToOffer - repeatedAbilitiesToReturnCount, UnacquiredAbilities().Count);

      List<AbilityUpgradeOption> upgradeOptions = GetRandomRepeatedAbilities(repeatedAbilitiesToReturnCount);
      upgradeOptions.AddRange(GetRandomUntappedAbilities(newAbilitiesToReturnCount));
      
      return upgradeOptions;
    }

    private List<AbilityUpgradeOption> GetRandomRepeatedAbilities(int count) =>
      _currentAbilities.Keys
        .OrderBy(_ => _random.Range(0, _currentAbilities.Count))
        .Take(count)
        .Select(abilityId => new AbilityUpgradeOption { Id = abilityId, Level = _currentAbilities[abilityId] + 1 })
        .ToList();

    private List<AbilityUpgradeOption> GetRandomUntappedAbilities(int count) =>
      UnacquiredAbilities()
        .OrderBy(_ => _random.Range(0, UnacquiredAbilities().Count))
        .Take(count)
        .Select(abilityId => new AbilityUpgradeOption { Id = abilityId, Level = 1 })
        .ToList();

    private List<AbilityId> UnacquiredAbilities() =>
      Enum
        .GetValues(typeof(AbilityId))
        .Cast<AbilityId>()
        .Except(_currentAbilities.Keys)
        .Except(_unavailableAbilities)
        .Except(new[] { AbilityId.Unknown })
        .ToList();

    public void Cleanup()
    {
      _currentAbilities.Clear();
    }
  }
}