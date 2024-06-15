using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
  public class MarkProcessedOnProducerDeadSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _armaments;
    private readonly IGroup<GameEntity> _enemies;

    public MarkProcessedOnProducerDeadSystem(GameContext game)
    {
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.ProducerId));
      
      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Id,
          GameMatcher.Enemy,
          GameMatcher.ProcessingDeath));
    }

    public void Execute()
    {
      foreach (GameEntity enemy in _enemies) 
      foreach (GameEntity armament in _armaments)
      {
        if (armament.ProducerId == enemy.Id)
          armament.isProcessed = true;
      }
    }
  }
}