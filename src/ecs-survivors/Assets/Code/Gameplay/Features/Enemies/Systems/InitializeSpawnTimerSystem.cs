using Code.Common.Entity;
using Code.Gameplay.Common;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
  public class InitializeSpawnTimerSystem : IInitializeSystem
  {
    public void Initialize()
    {
      CreateEntity.Empty()
        .AddSpawnTimer(GameplayConstants.EnemySpawnTimer);
    }
  }
}