using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class CleanupCollectedSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _collected;
    private readonly List<GameEntity> _buffer = new(128);

    public CleanupCollectedSystem(GameContext contextParameter)
    {
      _collected = contextParameter.GetGroup(GameMatcher.Collected);
    }

    public void Cleanup()
    {
      foreach (GameEntity collected in _collected.GetEntities(_buffer))
      {
        collected.isDestructed = true;
      }
    }
  }
}