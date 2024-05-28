using System.Collections.Generic;
using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class MarkReachedDestinationSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(16);

    public MarkReachedDestinationSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetDestination,
          GameMatcher.WorldPosition)
        .NoneOf(GameMatcher.Reached));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (Vector3.SqrMagnitude(entity.WorldPosition - entity.TargetDestination.ToVector3()) <= 0.1f)
        {
          entity.isReached = true;
          Debug.Log($"Reached!");
        }
      }
    }
  }
}