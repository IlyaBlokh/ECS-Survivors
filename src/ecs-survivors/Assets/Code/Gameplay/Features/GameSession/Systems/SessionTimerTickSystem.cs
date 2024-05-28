using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.GameSession.Systems
{
  public class SessionTimerTickSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _timers;

    public SessionTimerTickSystem(GameContext game, ITimeService time)
    {
      _time = time;
      _timers = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.SessionTimer));
    }

    public void Execute()
    {
      foreach (GameEntity timer in _timers) 
        timer.ReplaceSessionTimer(timer.SessionTimer + _time.DeltaTime);
    }
  }
}