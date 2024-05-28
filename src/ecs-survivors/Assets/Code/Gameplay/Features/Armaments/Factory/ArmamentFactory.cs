using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Armaments.Extensions;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
  public class ArmamentFactory : IArmamentFactory
  {
    private const int TargetBufferSize = 16;

    private readonly IIdentifierService _identifiers;
    private readonly IStaticDataService _staticDataService;

    public ArmamentFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
    {
      _identifiers = identifiers;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateVegetableBolt(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
      ProjectileSetup setup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel, setup)
          .AddParentAbility(AbilityId.VegetableBolt)
          .AddTargetCollecting()
          .With(x => x.isRotationAlignedAlongDirection = true)
        ;
    }

    public GameEntity CreateMushroom(int level, Vector3 at, float phase)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
      ProjectileSetup setup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel, setup)
          .AddParentAbility(AbilityId.OrbitingMushroom)
          .AddOrbitPhase(phase)
          .AddTargetCollecting()
          .AddOrbitRadius(setup.OrbitRadius)
        ;
    }

    public GameEntity CreateExplosion(int producerId, Vector3 at)
    {
      EnchantConfig config = _staticDataService.GetEnchantConfig(EnchantTypeId.ExplosiveArmaments);
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddLayerMask(CollisionLayer.Enemy.AsMask())
          .AddRadius(config.Radius)
          .With(x => x.AddEffectSetups(config.EffectSetups), when: !config.EffectSetups.IsNullOrEmpty())
          .With(x => x.AddStatusSetups(config.StatusSetups), when: !config.StatusSetups.IsNullOrEmpty())
          .AddViewPrefab(config.ViewPrefab)
          .AddProducerId(producerId)
          .AddWorldPosition(at)
          .With(x => x.isReadyToCollectTargets = true)
          .AddSelfDestructTimer(1)
        ;
    }

    public GameEntity CreateGarlicEffectAura(AbilityId parentAbilityId, int producerId, int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.GarlicAura, level);

      return CreateBaseAura(abilityLevel)
        .AddProducerFollow(producerId)
        .AddParentAbility(AbilityId.GarlicAura);
    }

    public GameEntity CreateSpeedUpEffectAura(AbilityId parentAbilityId, int producerId, int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.SpeedUpAura, level);

      return CreateBaseAura(abilityLevel)
        .AddProducerFollow(producerId)
        .AddParentAbility(AbilityId.SpeedUpAura);
    }

    public GameEntity CreateHealEffectAura(AbilityId parentAbilityId, int producerId, int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.HealAura, level);

      return CreateBaseAura(abilityLevel)
        .AddProducerFollow(producerId)
        .AddParentAbility(AbilityId.HealAura);
    }

    public GameEntity CreateNapalmBomb(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.NapalmBomb, level);
      ProjectileSetup setup = abilityLevel.ProjectileSetup;

      return CreateProjectileEntity(at, abilityLevel, setup)
          .AddParentAbility(AbilityId.NapalmBomb)
          .With(x => x.isRotationAlignedAlongDirection = true)
        ;
    }

    public GameEntity CreateNapalmAura(int level, Vector3 at)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.NapalmAura, level);

      return CreateBaseAura(abilityLevel)
        .AddParentAbility(AbilityId.NapalmAura)
        .ReplaceWorldPosition(at);
    }

    private GameEntity CreateBaseAura(AbilityLevel abilityLevel)
    {
      AuraSetup setup = abilityLevel.AuraSetup;

      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .With(x => x.isArmament = true)
          .AddViewPrefab(abilityLevel.ViewPrefab)
          .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
          .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
          .AddTargetBuffer(new List<int>(TargetBufferSize))
          .AddLayerMask(CollisionLayer.Enemy.AsMask())
          .AddRadius(setup.Radius)
          .AddCollectTargetsInterval(setup.Interval)
          .AddCollectTargetsTimer(0)
          .AddWorldPosition(Vector3.zero)
        ;
    }

    private GameEntity CreateProjectileEntity(Vector3 at, AbilityLevel abilityLevel, ProjectileSetup setup)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .With(x => x.isArmament = true)
        .AddViewPrefab(abilityLevel.ViewPrefab)
        .AddWorldPosition(at)
        .AddSpeed(setup.Speed)
        .With(x => x.AddEffectSetups(abilityLevel.EffectSetups), when: !abilityLevel.EffectSetups.IsNullOrEmpty())
        .With(x => x.AddStatusSetups(abilityLevel.StatusSetups), when: !abilityLevel.StatusSetups.IsNullOrEmpty())
        .With(x => x.AddTargetLimit(setup.Pierce), when: setup.Pierce > 0)
        .AddRadius(setup.ContactRadius)
        .AddLayerMask(CollisionLayer.Enemy.AsMask())
        .With(x => x.isMovementAvailable = true)
        .With(x => x.isReadyToCollectTargets = true)
        .AddSelfDestructTimer(setup.Lifetime);
    }
  }
}