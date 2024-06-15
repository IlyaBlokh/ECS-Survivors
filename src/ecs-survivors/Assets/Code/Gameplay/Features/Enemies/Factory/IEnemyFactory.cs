using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
  public interface IEnemyFactory
  {
    GameEntity CreateRandomEnemy(List<EnemyTypeId> availableTypes, Vector3 at);
  }
}