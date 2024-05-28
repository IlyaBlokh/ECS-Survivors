using Code.Gameplay.Features.GameSession.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.GameSession
{
  public sealed class GameSessionFeature : Feature
  {
    public GameSessionFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeSessionTimerSystem>());
      Add(systems.Create<SessionTimerTickSystem>());
    }
  }
}