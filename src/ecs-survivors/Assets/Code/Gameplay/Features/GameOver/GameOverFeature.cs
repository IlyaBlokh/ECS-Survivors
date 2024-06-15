using Code.Gameplay.Features.GameOver.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.GameOver
{
  public sealed class GameOverFeature : Feature
  {
    public GameOverFeature(ISystemFactory systems)
    {
      Add(systems.Create<GameOverOnHeroDeathSystem>());
      Add(systems.Create<StopEnemiesOnGameOver>());
    }
  }
}