using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enemies.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Registrars
{
  public class EnemyRegistrar : MonoBehaviour
  {
    public float Speed = 1;

    public EnemyAnimator EnemyAnimator;
    
    private GameEntity _entity;
    
    private void Awake()
    {
      _entity = CreateEntity.Empty();
      RegisterComponents();
    }

    private void RegisterComponents()
    {
      _entity
        .AddTransform(transform)
        .AddEnemyTypeId(EnemyTypeId.Goblin)
        .AddWorldPosition(transform.position)
        .AddDirection(Vector2.zero)
        .AddSpeed(Speed)
        .AddEnemyAnimator(EnemyAnimator)
        .AddSpriteRenderer(EnemyAnimator.SpriteRenderer)
        .With(x => x.isEnemy = true)
        .With(x => x.isTurnedAlongDirection = true)
        ;
    }
  }
}