using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class PullTowardsHeroSystem : IExecuteSystem
  {
    private const float LootSpeed = 4;
    private readonly IGroup<GameEntity> _pullables;
    private readonly IGroup<GameEntity> _heroes;
    private readonly List<GameEntity> _buffer = new(128);

    public PullTowardsHeroSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
      
      _pullables = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Pulling,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes) 
      foreach (GameEntity pullable in _pullables.GetEntities(_buffer))
      {
        pullable.ReplaceDirection((hero.WorldPosition - pullable.WorldPosition).normalized);
        pullable.ReplaceSpeed(LootSpeed);
        pullable.isMovementAvailable = true;
        pullable.isMoving = true;
      }
    }
  }
}