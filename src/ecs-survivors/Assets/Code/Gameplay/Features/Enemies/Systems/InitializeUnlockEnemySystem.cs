using Code.Gameplay.Features.Enemies.Factory;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
  public class InitializeUnlockEnemySystem : IInitializeSystem
  {
    private readonly IUnlockEnemyFactory _unlockEnemyFactory;

    public InitializeUnlockEnemySystem(IUnlockEnemyFactory unlockEnemyFactory)
    {
      _unlockEnemyFactory = unlockEnemyFactory;
    }
    
    public void Initialize()
    {
      _unlockEnemyFactory.CreateUnlockEnemy();
    }
  }
}