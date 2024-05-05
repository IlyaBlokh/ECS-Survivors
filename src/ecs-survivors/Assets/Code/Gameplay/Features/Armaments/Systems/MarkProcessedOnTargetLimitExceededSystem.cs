using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
  public class MarkProcessedOnTargetLimitExceededSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;
    private readonly List<GameEntity> _buffer = new(64);

    public MarkProcessedOnTargetLimitExceededSystem(GameContext game)
    {
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.TargetLimit,
          GameMatcher.ProcessedTargets));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments.GetEntities(_buffer))
      {
        if (armament.ProcessedTargets.Count >= armament.TargetLimit)
          armament.isProcessed = true;
      }
    }
  }
}