using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Hero.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Registrars
{
  public class HeroRegistrar : MonoBehaviour
  {
    public float Speed = 2;
    public HeroAnimator HeroAnimator;
    
    private GameEntity _entity;

    private void Awake()
    {
      _entity = CreateEntity
        .Empty()
        .AddTransform(transform)
        .AddWorldPosition(transform.position)
        .AddDirection(Vector2.zero)
        .AddSpeed(Speed)
        .AddHeroAnimator(HeroAnimator)
        .AddSpriteRenderer(HeroAnimator.SpriteRenderer)
        .With(x => x.isHero = true)
        .With(x => x.isTurnedAlongDirection = true)
        ;
    }
  }
}