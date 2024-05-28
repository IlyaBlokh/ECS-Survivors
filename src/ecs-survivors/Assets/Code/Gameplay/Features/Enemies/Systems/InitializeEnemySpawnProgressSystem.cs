using Code.Gameplay.Features.Enemies.Factory;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
  public class InitializeEnemySpawnProgressSystem : IInitializeSystem
  {
    private readonly IEnemySpawnProgressFactory _enemySpawnProgressFactory;

    public InitializeEnemySpawnProgressSystem(IEnemySpawnProgressFactory enemySpawnProgressFactory)
    {
      _enemySpawnProgressFactory = enemySpawnProgressFactory;
    }
    
    public void Initialize()
    {
      _enemySpawnProgressFactory.CreateUnlockEnemy();
    }
  }
}