using Cysharp.Threading.Tasks;

namespace Code.Infrastructure.States.StateInfrastructure
{
  public class EndOfFrameExitState : IState, IUpdateable
  {

    public virtual void Enter() { }

    void IUpdateable.Update() => 
      OnUpdate();

    protected virtual void OnUpdate() { }

    async UniTask IExitableState.BeginExit() => 
      await UniTask.NextFrame();

    void IExitableState.EndExit() => 
      ExitOnEndOfFrame();

    protected virtual void ExitOnEndOfFrame() { }
  }
}