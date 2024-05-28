using Code.Gameplay.Features.GameSession.Factory;
using Entitas;

namespace Code.Gameplay.Features.GameSession.Systems
{
  public class InitializeSessionTimerSystem : IInitializeSystem
  {
    private ITimerFactory _timerFactory;

    public InitializeSessionTimerSystem(ITimerFactory timerFactory)
    {
      _timerFactory = timerFactory;
    }
    
    public void Initialize()
    {
      _timerFactory.CreateSessionTimer();
    }
  }
}