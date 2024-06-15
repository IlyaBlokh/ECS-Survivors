using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class ScheduledProcessForBouncingBeerSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _armaments;
    private readonly List<GameEntity> _buffer = new(64);

    public ScheduledProcessForBouncingBeerSystem(GameContext game)
    {
      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ScheduledToProcessByArmaments,
          GameMatcher.Enemy));
      
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.BeerBoltArmament,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity enemy in _enemies)
        foreach (GameEntity armament in _armaments.GetEntities(_buffer))
        {
          if (enemy.ScheduledToProcessByArmaments.Contains(armament.Id))
          {
            armament.RequiresNextNearestEnemy = true;
            enemy.ProcessedByArmaments.Add(armament.Id);
            enemy.ScheduledToProcessByArmaments.Remove(armament.Id);
          }
        }
    }
  }
}