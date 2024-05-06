using System;
using System.Collections.Generic;
using Code.Gameplay.Common.Physics;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class ArmamentCastForTargetsWithLimitSystem : IExecuteSystem, ITearDownSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _armaments;
    private readonly List<GameEntity> _buffer = new(64);
    private GameEntity[] _targetCastBuffer = new GameEntity[128];

    public ArmamentCastForTargetsWithLimitSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.TargetsBuffer,
          GameMatcher.TargetLimit,
          GameMatcher.ProcessedTargets,
          GameMatcher.WorldPosition,
          GameMatcher.Radius,
          GameMatcher.LayerMask));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments.GetEntities(_buffer))
      {
        for (int i = 0; i < Math.Min(armament.TargetLimit, TargetCountInRadius(armament)); i++)
        {
          GameEntity targetEntity = _targetCastBuffer[i];
          int targetId = targetEntity.Id;
          if (!AlreadyProcessed(armament, targetId))
          {
            armament.TargetsBuffer.Add(targetId);
            armament.ProcessedTargets.Add(targetId);
            
            if (CouldBeProcessedByArmament(targetEntity))
              if (!targetEntity.ProcessedByArmaments.Contains(armament.Id))
                targetEntity.ScheduledToProcessByArmaments.Add(armament.Id);
          }
        }
      
        if (!armament.isCollectingTargetsContinuously)
          armament.isReadyToCollectTargets = false;
      }
    }

    private bool CouldBeProcessedByArmament(GameEntity targetEntity) => 
      targetEntity.hasScheduledToProcessByArmaments && targetEntity.hasProcessedByArmaments;

    private bool AlreadyProcessed(GameEntity entity, int targetId) => 
      entity.ProcessedTargets.Contains(targetId);

    private int TargetCountInRadius(GameEntity entity) =>
      _physicsService.CircleCastNonAlloc(entity.WorldPosition, entity.Radius, entity.LayerMask, _targetCastBuffer);

    public void TearDown() => 
      _targetCastBuffer = null;
  }
}