using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.CharacterStats;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Hero.Factory
{
  public class HeroFactory : IHeroFactory
  {
    private readonly IIdentifierService _identifiers;

    public HeroFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateHero(Vector3 at)
    {
      Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = 2)
        .With(x => x[Stats.MaxHp] = 100);
      
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddWorldPosition(at)
        .AddBaseStats(baseStats)
        .AddStatModifiers(InitStats.EmptyStatDictionary())
        .AddDirection(Vector2.zero)
        .AddSpeed(baseStats[Stats.Speed])
        .AddCurrentHp(baseStats[Stats.MaxHp])
        .AddMaxHp(baseStats[Stats.MaxHp])
        .AddExperience(0)
        .AddViewPath("Gameplay/Hero/hero")
        .AddPickupRadius(1f)
        .With(x => x.isHero = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true);
    }

  }
}