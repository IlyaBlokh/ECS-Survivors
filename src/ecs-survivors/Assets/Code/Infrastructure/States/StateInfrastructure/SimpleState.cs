using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
  public class SimpleState : IState, IUpdateable
  {
    public virtual void Enter() { }

    public virtual void Update() { }

    protected virtual void Exit() { }

    async UniTask IExitableState.BeginExit()
    {
      Exit();
      await UniTask.CompletedTask;
    }

    void IExitableState.EndExit() { }
  }
}