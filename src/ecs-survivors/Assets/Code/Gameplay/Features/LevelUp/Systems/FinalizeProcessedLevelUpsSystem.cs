using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
  public class FinalizeProcessedLevelUpsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _levelUps;

    public FinalizeProcessedLevelUpsSystem(GameContext game)
    {
      _levelUps = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.LevelUp,
          GameMatcher.Processed));
    }

    public void Execute()
    {
      foreach (GameEntity levelUp in _levelUps) 
        levelUp.isDestructed = true;
    }
  }
}