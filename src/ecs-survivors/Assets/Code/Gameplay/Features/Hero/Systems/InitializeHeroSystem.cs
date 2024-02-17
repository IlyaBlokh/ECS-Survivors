using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class InitializeHeroSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;
    private readonly ILevelDataProvider _levelDataProvider;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider, IAbilityUpgradeService abilityUpgradeService)
    {
      _heroFactory = heroFactory;
      _levelDataProvider = levelDataProvider;
      _abilityUpgradeService = abilityUpgradeService;
    }
    
    public void Initialize()
    {
      _heroFactory.CreateHero(_levelDataProvider.StartPoint);
      _abilityUpgradeService.InitializeAbility(AbilityId.VegetableBolt);
    }
  }
}