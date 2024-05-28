using Code.Common.Entity;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.StaticData;
using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
  public class LevelUpWindow : BaseWindow
  {
    public Transform AbilityLayout;
    
    private IAbilityUIFactory _abilityUIFactory;
    private IAbilityUpgradeService _abilityUpgradeService;
    private IStaticDataService _staticDataService;
    private IWindowService _windowService;

    [Inject]
    private void Construct(
      IAbilityUIFactory abilityUIFactory, 
      IAbilityUpgradeService abilityUpgradeService,
      IStaticDataService staticDataService,
      IWindowService windowService)
    {
      _abilityUIFactory = abilityUIFactory;
      _abilityUpgradeService = abilityUpgradeService;
      _staticDataService = staticDataService;
      _windowService = windowService;

      Id = WindowId.LevelUpWindow;
    }

    protected override void Initialize()
    {
      foreach (AbilityUpgradeOption upgradeOption in _abilityUpgradeService.GetUpgradeOptions())
      {
        AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(upgradeOption.Id, upgradeOption.Level);
        _abilityUIFactory
          .CreateAbilityCard(AbilityLayout)
          .Setup(upgradeOption.Id, abilityLevel, OnSelected);
      }
    }

    private void OnSelected(AbilityId abilityId)
    {
      CreateEntity.Empty()
        .AddAbilityId(abilityId)
        .isUpgradeRequest = true;
      
      _windowService.Close(Id);
    }
  }
}