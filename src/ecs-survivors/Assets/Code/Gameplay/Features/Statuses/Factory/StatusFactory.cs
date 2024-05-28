using System;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Enchants;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Statuses.Factory
{
  public class StatusFactory : IStatusFactory
  {
    private readonly IIdentifierService _identifiers;

    public StatusFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateStatus(StatusSetup setup, int producerId, int targetId)
    {
      GameEntity status = setup.StatusTypeId switch
      {
        StatusTypeId.Poison => CreatePoisonStatus(setup, producerId, targetId),
        StatusTypeId.Freeze => CreateFreezeStatus(setup, producerId, targetId),
        StatusTypeId.SpeedChange => CreateSpeedChangeStatus(setup, producerId, targetId),
        StatusTypeId.PoisonEnchant => CreatePoisonEnchantStatus(setup, producerId, targetId),
        StatusTypeId.ExplosiveEnchant => CreateExplosiveEnchantStatus(setup, producerId, targetId),
        StatusTypeId.HexEnchant => CreateHexEnchantStatus(setup, producerId, targetId),
        StatusTypeId.Metamorph => CreateMetamorphStatus(setup, producerId, targetId),
        StatusTypeId.Heal => CreateHealStatus(setup, producerId, targetId),
        _ => throw new Exception($"Status with type id {setup.StatusTypeId} does not exist")
      };

      status
        .With(x => x.AddDuration(setup.Duration), when: setup.Duration > 0)
        .With(x => x.AddTimeLeft(setup.Duration), when: setup.Duration > 0)
        .With(x => x.AddPeriod(setup.Period), when: setup.Period > 0)
        .With(x => x.AddTimeSinceLastTick(0), when: setup.Period > 0)
        ;
      
      return status;
    }

    private GameEntity CreatePoisonStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddStatusTypeId(StatusTypeId.Poison)
        .AddEffectValue(setup.Value)
        .AddProducerId(producerId)
        .AddTargetId(targetId)
        .With(x => x.isStatus = true)
        .With(x => x.isPoison = true)
        ;
    }

    private GameEntity CreateHealStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddStatusTypeId(StatusTypeId.Heal)
          .AddEffectValue(setup.Value)
          .AddProducerId(producerId)
          .AddTargetId(targetId)
          .With(x => x.isStatus = true)
          .With(x => x.isHeal = true)
        ;
    }

    private GameEntity CreateFreezeStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddStatusTypeId(StatusTypeId.Freeze)
        .AddEffectValue(setup.Value)
        .AddProducerId(producerId)
        .AddTargetId(targetId)
        .With(x => x.isStatus = true)
        .With(x => x.isFreeze = true)
        ;
    }

    private GameEntity CreateSpeedChangeStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddStatusTypeId(StatusTypeId.SpeedChange)
          .AddEffectValue(setup.Value)
          .AddProducerId(producerId)
          .AddTargetId(targetId)
          .With(x => x.isStatus = true)
          .With(x => x.isSpeedChange = true)
        ;
    }

    private GameEntity CreatePoisonEnchantStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddStatusTypeId(StatusTypeId.PoisonEnchant)
          .AddEnchantTypeId(EnchantTypeId.PoisonArmaments)
          .AddEffectValue(setup.Value)
          .AddProducerId(producerId)
          .AddTargetId(targetId)
          .With(x => x.isStatus = true)
          .With(x => x.isPoisonEnchant = true)
        ;
    }

    private GameEntity CreateExplosiveEnchantStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddStatusTypeId(StatusTypeId.ExplosiveEnchant)
          .AddEnchantTypeId(EnchantTypeId.ExplosiveArmaments)
          .AddEffectValue(setup.Value)
          .AddProducerId(producerId)
          .AddTargetId(targetId)
          .With(x => x.isStatus = true)
          .With(x => x.isExplosiveEnchant = true)
        ;
    }

    private GameEntity CreateHexEnchantStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddStatusTypeId(StatusTypeId.HexEnchant)
          .AddEnchantTypeId(EnchantTypeId.HexArmaments)
          .AddEffectValue(setup.Value)
          .AddProducerId(producerId)
          .AddTargetId(targetId)
          .With(x => x.isStatus = true)
          .With(x => x.isHexEnchant = true)
        ;
    }

    private GameEntity CreateMetamorphStatus(StatusSetup setup, int producerId, int targetId)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddStatusTypeId(StatusTypeId.Metamorph)
          .AddProducerId(producerId)
          .AddTargetId(targetId)
          .With(x => x.isStatus = true)
          .With(x => x.isMetamorph = true)
        ;
    }
  }
}