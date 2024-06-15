using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
  public class EndOfFrameExitState : IState, IUpdateable
  {
    private Promise _exitPromise;
    private bool ExitWasRequested => _exitPromise != null;

    public virtual void Enter() { }

    void IUpdateable.Update()
    {
      if (!ExitWasRequested)
        OnUpdate();
      
      if (ExitWasRequested)
        ResolveExitPromise();
    }

    protected virtual void OnUpdate() { }

    IPromise IExitableState.BeginExit()
    {
      _exitPromise = new Promise();
      return _exitPromise;
    }

    void IExitableState.EndExit()
    {
      ExitOnEndOfFrame();
      ClearExitPromise();
    }

    protected virtual void ExitOnEndOfFrame() { }

    private void ResolveExitPromise() => 
      _exitPromise?.Resolve();

    private void ClearExitPromise() => 
      _exitPromise = null;
  }
}