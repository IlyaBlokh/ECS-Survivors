using Code.Infrastructure.Loading;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;

namespace Code.Infrastructure.States.GameStates
{
  public class LoadingHomeScreenState : IState
  {
    private const string HomeScreenSceneName = "HomeScreen";
    private readonly IGameStateMachine _stateMachine;
    private readonly ISceneLoader _sceneLoader;

    public LoadingHomeScreenState(IGameStateMachine stateMachine, ISceneLoader sceneLoader)
    {
      _stateMachine = stateMachine;
      _sceneLoader = sceneLoader;
    }
    
    public void Enter()
    {
      _sceneLoader.LoadScene(HomeScreenSceneName, EnterHomeScreenState);
    }

    private void EnterHomeScreenState()
    {
      _stateMachine.Enter<HomeScreenState>();
    }

    public void Exit()
    {
      
    }
  }
}