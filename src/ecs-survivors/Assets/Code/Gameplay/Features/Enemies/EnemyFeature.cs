using Code.Gameplay.Features.Enemies.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enemies
{
  public class EnemyFeature : Feature
  {
    public EnemyFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeTimerSystem>());
      
      Add(systems.Create<EnemySpawnSystem>());
      Add(systems.Create<ChaseHeroSystem>());
      Add(systems.Create<EnemyDeathSystem>());
      Add(systems.Create<FinalizeEnemyDeathProcessingSystem>());
    }
  }
}