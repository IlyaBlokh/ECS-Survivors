using Code.Common.Entity;
using Code.Gameplay;
using Code.Gameplay.Providers;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;

namespace Code.Infrastructure.States.GameStates
{
  public class BattleLoopState : SimpleState
  {
    private readonly ISystemFactory _systems;
    private readonly IBattleFeatureProvider _battleFeatureProvider;
    
    private BattleFeature _battleFeature;

    public BattleLoopState(ISystemFactory systems, IBattleFeatureProvider battleFeatureProvider)
    {
      _systems = systems;
      _battleFeatureProvider = battleFeatureProvider;
    }
    
    public override void Enter()
    {
      _battleFeature = _systems.Create<BattleFeature>();
      _battleFeature.Initialize();
      _battleFeatureProvider.BattleFeature = _battleFeature;
    }
    
    public override void Update()
    {
      _battleFeature.Execute();
      _battleFeature.Cleanup();
    }

    protected override void Exit()
    {
      CreateEntity.Empty()
        .isGameOver = true;
    }
  }
}