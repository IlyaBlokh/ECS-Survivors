using System.Collections.Generic;
using Code.Common.Entity;

namespace Code.Gameplay.Features.Enemies.Factory
{
  public class UnlockEnemyFactory : IUnlockEnemyFactory
  {
    public GameEntity CreateUnlockEnemy()
    {
      return CreateEntity.Empty()
        .AddEnemyTypes(new List<EnemyTypeId>());
    }
  }
}