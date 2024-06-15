using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Configs
{
  [CreateAssetMenu(menuName = "ECS Survivors/EnemyConfig", fileName = "EnemyConfig", order = 0)]
  public class EnemyConfig : ScriptableObject
  {
    public EnemyTypeId TypeId;
    public float MaxHp;
    public float Speed;
    public float Damage;
  }
}