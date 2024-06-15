using RSG;

namespace Code.Infrastructure.States.StateInfrastructure
{
  public class SimpleState : IState, IUpdateable
  {
    public virtual void Enter()
    {
      
    }

    public virtual void Update()
    {
      
    }

    protected virtual void Exit()
    {
      
    }

    IPromise IExitableState.BeginExit()
    {
      Exit();
      return Promise.Resolved();
    }

    void IExitableState.EndExit() { }
  }
}