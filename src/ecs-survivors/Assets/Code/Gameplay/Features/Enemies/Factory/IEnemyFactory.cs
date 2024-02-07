using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
  public interface IEnemyFactory
  {
    GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at);
  }
}