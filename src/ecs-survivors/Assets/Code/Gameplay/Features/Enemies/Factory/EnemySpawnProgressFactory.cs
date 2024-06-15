using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;

namespace Code.Gameplay.Features.Enemies.Factory
{
  public class EnemySpawnProgressFactory : IEnemySpawnProgressFactory
  {
    public GameEntity CreateUnlockEnemy()
    {
      return CreateEntity.Empty()
        .With(x => x.isSpawnProgress = true)
        .AddEnemyTypes(new List<EnemyTypeId>());
    }
  }
}