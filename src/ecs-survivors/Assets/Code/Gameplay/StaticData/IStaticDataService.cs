using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Windows;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    AbilityConfig GetAbilityConfig(AbilityId abilityId);
    AbilityLevel GetAbilityLevel(AbilityId abilityId, int level);
    EnchantConfig GetEnchantConfig(EnchantTypeId typeId);
    
    GameObject GetWindowPrefab(WindowId id);
  }
}