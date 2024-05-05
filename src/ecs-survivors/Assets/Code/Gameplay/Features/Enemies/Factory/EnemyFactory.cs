using System;
using System.Collections.Generic;
using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Factory
{
  public class EnemyFactory : IEnemyFactory
  {
    private readonly IIdentifierService _identifiers;

    private readonly float HP = 3;
    private readonly float Damage = 1;
    private readonly float Speed = 1;

    public EnemyFactory(IIdentifierService identifiers)
    {
      _identifiers = identifiers;
    }

    public GameEntity CreateEnemy(EnemyTypeId typeId, Vector3 at)
    {
      switch (typeId)
      {
        case EnemyTypeId.Goblin:
          return CreateGoblin(at);
      }

      throw new Exception($"Enemy with type {typeId} doesn't exist");
    }
    
    private GameEntity CreateGoblin(Vector3 at)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddEnemyTypeId(EnemyTypeId.Goblin)
        .AddWorldPosition(at)
        .AddDirection(Vector2.zero)
        .AddSpeed(Speed)
        .AddCurrentHP(HP)
        .AddMaxHP(HP)
        .AddDamage(Damage)
        .AddTargetsBuffer(new List<int>(1))
        .AddRadius(0.3f)
        .AddCollectTargetsInterval(0.5f)
        .AddCollectTargetsTimer(0)
        .AddLayerMask(CollisionLayer.Hero.AsMask())
        .AddViewPath("Gameplay/Enemies/Goblins/Torch/goblin_torch_blue")
        .With(x => x.isEnemy = true)
        .With(x => x.isTurnedAlongDirection = true)
        .With(x => x.isMovementAvailable = true);
    }
    
    
  }
}