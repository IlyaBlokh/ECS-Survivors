using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Effects.Factory
{
  public class EffectFactory : IEffectFactory
  {
    private readonly IIdentifierService _identifiers;

    public EffectFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateEffect(EffectSetup setup, int producerId, int targetId)
    {
      switch (setup.EffectTypeId)
      {
        case EffectTypeId.Unknown:
          break;
        case EffectTypeId.Damage:
          return CreateDamage(producerId, targetId, setup.Value);
        case EffectTypeId.Heal:
          return CreateHeal(producerId, targetId, setup.Value);
      }

      throw new Exception($"Effect with type id {setup.EffectTypeId} does not exist");
    }

    private GameEntity CreateDamage(int producerId, int targetId, float value)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .With(x => x.isEffect = true)
        .With(x => x.isDamageEffect = true)
        .AddEffectValue(value)
        .AddProducerId(producerId)
        .AddTargetId(targetId);
    }

    private GameEntity CreateHeal(int producerId, int targetId, float value)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .With(x => x.isEffect = true)
        .With(x => x.isHealEffect = true)
        .AddEffectValue(value)
        .AddProducerId(producerId)
        .AddTargetId(targetId);
    }
  }
}