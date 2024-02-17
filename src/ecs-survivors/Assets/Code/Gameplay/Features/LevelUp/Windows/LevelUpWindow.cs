using System.Collections.Generic;
using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
  public class LevelUpWindow : BaseWindow
  {
    public Transform AbilityLayout;

    private IStaticDataService _staticData;
    private IAbilityUpgradeService _abilityUpgrade;

    private List<AbilityCard> _cards = new(3);
    private IWindowService _windowService;
    private IAbilityUIFactory _factory;

    [Inject]
    private void Construct(
      IStaticDataService staticData, 
      IAbilityUpgradeService abilityUpgrade, 
      IWindowService windowService,
      IAbilityUIFactory abilityUIFactory)
    {
      Id = WindowId.LevelUpWindow;

      _staticData = staticData;
      _abilityUpgrade = abilityUpgrade;
      _windowService = windowService;
      _factory = abilityUIFactory;
    }

    protected override void Initialize()
    {
      foreach (AbilityUpgradeOption upgradeOption in _abilityUpgrade.GetUpgradeOptions())
      {
        AbilityLevel abilityLevel = _staticData.GetAbilityLevel(upgradeOption.Id, upgradeOption.Level);

        _cards.Add(
          _factory.CreateAbilityCard(AbilityLayout)
            .Setup(upgradeOption.Id, abilityLevel, OnSelected));
      }
    }

    private void OnSelected(AbilityId id)
    {
      CreateEntity.Empty()
        .AddAbilityId(id)
        .isUpgradeRequest = true;

      _windowService.Close(Id);
    }
  }
}