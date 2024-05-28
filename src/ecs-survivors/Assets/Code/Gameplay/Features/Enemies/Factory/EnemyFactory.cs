using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IIdentifierService _identifiers;
    private readonly IAbilityFactory _abilityFactory;
    private readonly IStaticDataService _staticDataService;

    public EnemyFactory(IIdentifierService identifiers, IAbilityFactory abilityFactory, IStaticDataService staticDataService)
    {
      _identifiers = identifiers;
      _abilityFactory = abilityFactory;
      _staticDataService = staticDataService;
    }
    
    public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
    {
      switch (typeId)
      {
        case EnemyTypeId.Goblin:
          return CreateGoblin(at);
        case EnemyTypeId.Buffer:
          return CreateBuffer(at);
        case EnemyTypeId.Healer:
          return CreateHealer(at);
      }

      throw new Exception($"Enemy with type id {typeId} does not exist");
    }

    private GameEntity CreateGoblin(Vector2 at)
    {
      Dictionary<Stats, float> baseStats = LoadBaseStats(EnemyTypeId.Goblin);
      
      return
        CreateEnemyBase(at, baseStats)
          .AddEnemyTypeId(EnemyTypeId.Goblin)
          .With(x => x.isGoblin = true)
          .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue");
    }

    private GameEntity CreateBuffer(Vector3 at)
    {
      Dictionary<Stats, float> baseStats = LoadBaseStats(EnemyTypeId.Buffer);

      GameEntity bufferEnemy = 
        CreateEnemyBase(at, baseStats)
          .AddEnemyTypeId(EnemyTypeId.Buffer)
          .With(x => x.isBuffer = true)
          .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_red");
      
      _abilityFactory.CreateSpeedUpAuraAbility(bufferEnemy.Id);
      return bufferEnemy;
    }

    private GameEntity CreateHealer(Vector3 at)
    {
      Dictionary<Stats, float> baseStats = LoadBaseStats(EnemyTypeId.Healer);
      
      GameEntity healerEnemy = 
        CreateEnemyBase(at, baseStats)
          .AddEnemyTypeId(EnemyTypeId.Healer)
          .With(x => x.isHealer = true)
          .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_yellow");
      
      _abilityFactory.CreateHealAuraAbility(healerEnemy.Id);
      return healerEnemy;
    }

    private GameEntity CreateEnemyBase(Vector2 at, Dictionary<Stats, float> baseStats)
    {
      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddWorldPosition(at)
          .AddDirection(Vector2.zero)
          .AddBaseStats(baseStats)
          .AddStatModifiers(InitStats.EmptyStatDictionary())
          .AddSpeed(baseStats[Stats.Speed])
          .AddCurrentHp(baseStats[Stats.MaxHp])
          .AddMaxHp(baseStats[Stats.MaxHp])
          .AddEffectSetups(new List<EffectSetup>{new(){EffectTypeId = EffectTypeId.Damage, Value = baseStats[Stats.Damage]}})
          .AddRadius(0.3f)
          .AddTargetBuffer(new List<int>(1))
          .AddCollectTargetsInterval(0.5f)
          .AddCollectTargetsTimer(0f)
          .AddLayerMask(CollisionLayer.Hero.AsMask())
          .With(x => x.isEnemy = true)
          .With(x => x.isTurnedAlongDirection = true)
          .With(x => x.isMovementAvailable = true)
        ;
    }

    private Dictionary<Stats, float> LoadBaseStats(EnemyTypeId typeId)
    {
      EnemyConfig config = _staticDataService.GetEnemyConfig(typeId); 
      return InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = config.Speed)
        .With(x => x[Stats.MaxHp] = config.MaxHp)
        .With(x => x[Stats.Damage] = config.Damage);
    }
  }
}