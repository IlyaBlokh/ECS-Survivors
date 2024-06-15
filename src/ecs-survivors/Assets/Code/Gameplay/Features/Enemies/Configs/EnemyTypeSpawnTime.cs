using System;

namespace Code.Gameplay.Features.Enemies.Configs
{
  [Serializable]
  public struct EnemyTypeSpawnTime
  {
    public EnemyTypeId TypeId;
    public float PassedTime;
  }
}