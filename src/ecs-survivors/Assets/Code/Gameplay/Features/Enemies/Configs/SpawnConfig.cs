using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Configs
{
  [CreateAssetMenu(menuName = "ECS Survivors/SpawnConfig", fileName = "SpawnConfig", order = 0)]
  public class SpawnConfig : ScriptableObject
  {
    public List<EnemyTypeSpawnTime> EnemyTypeSpawnTimes;
    public List<int> EnemyInWaveByHeroLevel;
  }
}