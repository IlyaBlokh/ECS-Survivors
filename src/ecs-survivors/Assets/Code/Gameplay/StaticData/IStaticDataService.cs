using System.Collections.Generic;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
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
    LootConfig GetLootConfig(LootTypeId typeId);
    int MaxLevel();
    float ExperienceForLevel(int level);
    EnemyConfig GetEnemyConfig(EnemyTypeId typeId);
    List<EnemyTypeSpawnTime> EnemyTypeSpawnTimes { get; }
  }
}