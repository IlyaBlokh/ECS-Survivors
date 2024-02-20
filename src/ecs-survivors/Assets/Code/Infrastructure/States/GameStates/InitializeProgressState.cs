using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Common.Time;
using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Progress.Data;
using Code.Progress.Provider;

namespace Code.Infrastructure.States.GameStates
{
  public class InitializeProgressState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IProgressProvider _progressProvider;
    private readonly IStaticDataService _staticDataService;
    private readonly ITimeService _timeService;

    public InitializeProgressState(
      IGameStateMachine stateMachine,
      IProgressProvider progressProvider,
      IStaticDataService staticDataService,
      ITimeService timeService)
    {
      _stateMachine = stateMachine;
      _progressProvider = progressProvider;
      _staticDataService = staticDataService;
      _timeService = timeService;
    }
    
    public void Enter()
    {
      InitializeProgress();

      _stateMachine.Enter<ActualizeProgressState>();
    }

    private void InitializeProgress()
    {
      CreateNewProgress();
    }

    private void CreateNewProgress()
    {
      _progressProvider.SetProgressData(new ProgressData()
      {
        LastSimulationTickTime = _timeService.UtcNow
      });

      CreateMetaEntity.Empty()
        .With(x => x.isStorage = true)
        .AddGold(0)
        .AddGoldPerSecond(_staticDataService.AfkGain.GoldPerSecond);
    }

    public void Exit()
    {
    }
  }
}