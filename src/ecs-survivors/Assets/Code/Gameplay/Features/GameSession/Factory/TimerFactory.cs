using Code.Common.Entity;

namespace Code.Gameplay.Features.GameSession.Factory
{
  public class TimerFactory : ITimerFactory
  {
    public GameEntity CreateSessionTimer()
    {
      return CreateEntity.Empty()
        .AddSessionTimer(0);
    }
  }
}