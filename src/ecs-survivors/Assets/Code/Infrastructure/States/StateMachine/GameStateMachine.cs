using Code.Infrastructure.States.Factory;
using Code.Infrastructure.States.StateInfrastructure;
using Cysharp.Threading.Tasks;
using Zenject;

namespace Code.Infrastructure.States.StateMachine
{
  public class GameStateMachine : IGameStateMachine, ITickable
  {
    private IExitableState _activeState;
    private readonly IStateFactory _stateFactory;

    public GameStateMachine(IStateFactory stateFactory)
    {
      _stateFactory = stateFactory;
    }

    public void Tick()
    {
      if(_activeState is IUpdateable updateableState)
        updateableState.Update();
    }

    public void Enter<TState>() where TState : class, IState =>
      RequestEnter<TState>();

    public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload> =>
      RequestEnter<TState, TPayload>(payload);

    private async void RequestEnter<TState>() where TState : class, IState
    {
      TState state = await RequestChangeState<TState>();
      EnterState(state);
    }

    private async void RequestEnter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
    {
      TState state = await RequestChangeState<TState>();
      EnterPayloadState(state, payload);
    }

    private void EnterState<TState>(TState state) where TState : class, IState
    {
      _activeState = state;
      state.Enter();
    }

    private void EnterPayloadState<TState, TPayload>(TState state, TPayload payload) where TState : class, IPayloadState<TPayload>
    {
      _activeState = state;
      state.Enter(payload);
    }

    private async UniTask<TState> RequestChangeState<TState>() where TState : class, IExitableState
    {
      if (_activeState != null)
      {
        await _activeState.BeginExit();
        _activeState.EndExit();
        return GetState<TState>();
      }

      return GetState<TState>();
    }
    
    private TState GetState<TState>() where TState : class, IExitableState => 
      _stateFactory.GetState<TState>();
  }
}