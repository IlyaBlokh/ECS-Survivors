using Code.Gameplay.StaticData;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class BootstrapState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly IStaticDataService _staticDataService;

    public BootstrapState(IGameStateMachine stateMachine, IStaticDataService staticDataService)
    {
      _stateMachine = stateMachine;
      _staticDataService = staticDataService;
    }
    
    public void Enter()
    {
      _staticDataService.LoadAll();
      
      _stateMachine.Enter<InitializeProgressState>();
    }

    public void Exit()
    {
      
    }
  }
}