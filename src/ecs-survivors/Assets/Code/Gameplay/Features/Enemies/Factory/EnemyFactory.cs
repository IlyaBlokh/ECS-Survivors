using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Factory;
using Code.Gameplay.Features.CharacterStats;
using Code.Gameplay.Features.Effects;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IIdentifierService _identifiers;
    private readonly IAbilityFactory _abilityFactory;

    public EnemyFactory(IIdentifierService identifiers, IAbilityFactory abilityFactory)
    {
      _identifiers = identifiers;
      _abilityFactory = abilityFactory;
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
      Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = 1)
        .With(x => x[Stats.MaxHp] = 5)
        .With(x => x[Stats.Damage] = 1);
      
      return
        CreateEnemyBase(at, baseStats)
          .AddEnemyTypeId(EnemyTypeId.Goblin)
          .With(x => x.isGoblin = true)
          .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue");
    }

    private GameEntity CreateBuffer(Vector3 at)
    {
      Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = 1f)
        .With(x => x[Stats.MaxHp] = 3)
        .With(x => x[Stats.Damage] = 0.5f);


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
      Dictionary<Stats, float> baseStats = InitStats.EmptyStatDictionary()
        .With(x => x[Stats.Speed] = 1f)
        .With(x => x[Stats.MaxHp] = 2)
        .With(x => x[Stats.Damage] = 0.5f);


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
  }
}