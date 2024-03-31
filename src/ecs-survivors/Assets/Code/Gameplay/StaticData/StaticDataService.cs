using System;
using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.Features.LevelUp;
using Code.Gameplay.Features.Loot;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.Windows;
using Code.Gameplay.Windows.Configs;
using Code.Meta.Features.AfkGain.Configs;
using Code.Meta.UI.Shop.Items;
using UnityEngine;

namespace Code.Gameplay.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private Dictionary<AbilityId,AbilityConfig> _abilityById;
    private Dictionary<EnchantTypeId, EnchantConfig> _enchantById;
    private Dictionary<LootTypeId, LootConfig> _lootById;
    private Dictionary<WindowId, GameObject> _windowPrefabsById;
    private List<ShopItemConfig> _shopItemConfigs;
    private LevelUpConfig _levelUp;
    private AfkGainConfig _afkGainConfig;

    public AfkGainConfig AfkGain => _afkGainConfig;

    public void LoadAll()
    {
      LoadAbilities();
      LoadEnchants();
      LoadLoot();
      LoadWindows();
      LoadShopItems();
      LoadLevelUpRules();
      LoadAfkGainConfig();
    }

    public AbilityConfig GetAbilityConfig(AbilityId abilityId)
    {
      if (_abilityById.TryGetValue(abilityId, out AbilityConfig config))
        return config;

      throw new Exception($"Ability config for {abilityId} was not found");
    }

    public LootConfig GetLootConfig(LootTypeId lootTypeId)
    {
      if (_lootById.TryGetValue(lootTypeId, out LootConfig config))
        return config;

      throw new Exception($"Loot config for {lootTypeId} was not found");
    }

    public ShopItemConfig GetShopItemConfig(ShopItemId shopItemId) => 
      _shopItemConfigs.FirstOrDefault(x => x.ShopItemId == shopItemId);

    public List<ShopItemConfig> GetShopItemConfigs() => 
      _shopItemConfigs;

    public AbilityLevel GetAbilityLevel(AbilityId abilityId, int level)
    {
      AbilityConfig config = GetAbilityConfig(abilityId);

      if (level > config.Levels.Count)
        level = config.Levels.Count;

      return config.Levels[level - 1];
    }

    public int MaxLevel() => _levelUp.MaxLevel;

    public float ExperienceForLevel(int level) =>
      _levelUp.ExperienceForLevel[level];

    public GameObject GetWindowPrefab(WindowId id) =>
      _windowPrefabsById.TryGetValue(id, out GameObject prefab)
        ? prefab
        : throw new Exception($"Prefab config for window {id} was not found");

    public EnchantConfig GetEnchantConfig(EnchantTypeId typeId)
    {
      if (_enchantById.TryGetValue(typeId, out EnchantConfig config))
        return config;

      throw new Exception($"Enchant config for {typeId} was not found");
    }

    private void LoadEnchants()
    {
      _enchantById = Resources
        .LoadAll<EnchantConfig>("Configs/Enchants")
        .ToDictionary(x => x.TypeId, x => x);
    }

    private void LoadAfkGainConfig()
    {
      _afkGainConfig = Resources.Load<AfkGainConfig>("Configs/AfkGainConfig");
    }

    private void LoadAbilities()
    {
      _abilityById = Resources
        .LoadAll<AbilityConfig>("Configs/Abilities")
        .ToDictionary(x => x.AbilityId, x => x);
    }

    private void LoadLoot()
    {
      _lootById = Resources
        .LoadAll<LootConfig>("Configs/Loot")
        .ToDictionary(x => x.LootTypeId, x => x);
    }

    private void LoadShopItems() =>
      _shopItemConfigs = Resources.LoadAll<ShopItemConfig>("Configs/ShopItems").ToList();

    private void LoadWindows()
    {
      _windowPrefabsById = Resources
        .Load<WindowsConfig>("Configs/Windows/windowsConfig")
        .WindowConfigs
        .ToDictionary(x => x.Id, x => x.Prefab);
    }
    
    private void LoadLevelUpRules()
    {
      _levelUp = Resources
        .Load<LevelUpConfig>("Configs/LevelUp/levelUpConfig");
    }
  }
}