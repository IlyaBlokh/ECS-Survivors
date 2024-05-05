using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<AbilityId,AbilityConfig> _abilityById;

    public void LoadAll()
    {
      LoadAbilities();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abilityById.TryGetValue(abilityId, out AbilityConfig config))
        return config;

      throw new Exception($"Ability config for {abilityId} not found");
    }

    private void LoadAbilities()
    {
      _abilityById = Resources
        .LoadAll<AbilityConfig>("Configs/Abilities")
        .ToDictionary(x => x.AbilityId, x => x);
    }
  }
}