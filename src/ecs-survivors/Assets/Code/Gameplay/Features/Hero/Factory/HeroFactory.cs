using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
    private const float HeroHp = 100;
    
    private readonly IIdentifierService _identifiers;

    public HeroFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateHero(Vector3 at)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddWorldPosition(at)
        .AddDirection(Vector2.zero)
        .AddSpeed(2)
        .AddCurrentHp(HeroHp)
        .AddMaxHp(HeroHp)
        .AddViewPath("Gameplay/Hero/hero")
        .With(x => x.isHero = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true);
    }

  }
}