using Code.Common.Extensions;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class RotateAlongDirectionSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _rotaters;

    public RotateAlongDirectionSystem(GameContext game)
    {
      _rotaters = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.RotationAlignedAlongDirection,
          GameMatcher.Transform,
          GameMatcher.Direction));
    }
    
    public void Execute()
    {
      foreach (GameEntity rotator in _rotaters)
      {
        if (rotator.Direction.sqrMagnitude >= 0.01f)
        {
          float angle = Mathf.Atan2(rotator.Direction.y, rotator.Direction.x) * Mathf.Rad2Deg;
          rotator.Transform.rotation = Quaternion.Euler(0, 0, angle);
        }
      }
    }
  }
}