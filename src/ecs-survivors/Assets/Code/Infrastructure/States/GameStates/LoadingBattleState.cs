using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadingBattleState : IPayloadState<string>
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadingBattleState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public void Enter(string sceneName)
    {
      _sceneLoader.LoadScene(sceneName, EnterBattleLoopState);
    }

    private void EnterBattleLoopState()
    {
      _stateMachine.Enter<BattleEnterState>();
    }

    public void Exit()
    {
      
    }
  }
}