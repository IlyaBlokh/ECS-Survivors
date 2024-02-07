using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class CastForTargetsNoLimitSystem : IExecuteSystem
  {
    private readonly IPhysicsService _physicsService;
    private readonly IGroup<GameEntity> _ready;
    private readonly List<GameEntity> _buffer = new(64);

    public CastForTargetsNoLimitSystem(GameContext game, IPhysicsService physicsService)
    {
      _physicsService = physicsService;
      _ready = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ReadyToCollectTargets,
          GameMatcher.Radius,
          GameMatcher.TargetBuffer,
          GameMatcher.WorldPosition,
          GameMatcher.LayerMask)
        .NoneOf(GameMatcher.TargetLimit)
      );
    }

    public void Execute()
    {
      foreach (GameEntity entity in _ready.GetEntities(_buffer))
      {
        entity.TargetBuffer.AddRange(TargetsInRadius(entity));

        if (!entity.isCollectingTargetsContinuously)
          entity.isReadyToCollectTargets = false;
      }
    }
    
    private IEnumerable<int> TargetsInRadius(GameEntity entity)
    {
      return _physicsService.CircleCast(entity.WorldPosition, radius: entity.Radius, entity.LayerMask)
        .Select(x => x.Id);
    }
  }
}