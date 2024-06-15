using Code.Gameplay;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Providers;
using Code.Gameplay.Windows;
using Code.Infrastructure.States.StateInfrastructure;

namespace Code.Infrastructure.States.GameStates
{
  public class GameOverState : EndOfFrameExitState
  {
    private readonly IWindowService _windowService;
    private readonly IAbilityUpgradeService _abilityUpgradeService;
    private readonly IBattleFeatureProvider _battleFeatureProvider;
    private readonly GameContext _gameContext;
    
    private BattleFeature _battleFeature;

    public GameOverState(
      IWindowService windowService,
      IAbilityUpgradeService abilityUpgradeService,
      IBattleFeatureProvider battleFeatureProvider,
      GameContext gameContext)
    {
      _battleFeatureProvider = battleFeatureProvider;
      _gameContext = gameContext;
      _abilityUpgradeService = abilityUpgradeService;
      _windowService = windowService;
    }
    
    public override void Enter()
    {
      _battleFeature = _battleFeatureProvider.BattleFeature;
      _abilityUpgradeService.Cleanup();
      _windowService.Open(WindowId.GameOverWindow);
    }

    protected override void ExitOnEndOfFrame()
    {
      _battleFeature.DeactivateReactiveSystems();
      _battleFeature.ClearReactiveSystems();

      DestructEntities();
      
      _battleFeature.Cleanup();
      _battleFeature.TearDown();
      _battleFeature = null;
    }

    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;
    }
  }
}