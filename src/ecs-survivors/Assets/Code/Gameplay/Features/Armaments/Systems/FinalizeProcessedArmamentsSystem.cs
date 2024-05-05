using System.Collections.Generic;
using Code.Gameplay.Features.TargetCollection;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
  public class FinalizeProcessedArmamentsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;
    private readonly List<GameEntity> _buffer = new(64);

    public FinalizeProcessedArmamentsSystem(GameContext game)
    {
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament, 
          GameMatcher.Processed));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments.GetEntities(_buffer))
      {
        armament.RemoveTargetCollectionComponents();
        armament.isDestructed = true;
      }
    }
  }
}