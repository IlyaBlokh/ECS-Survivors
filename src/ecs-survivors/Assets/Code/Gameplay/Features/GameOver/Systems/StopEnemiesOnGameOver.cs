using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.GameOver.Systems
{
  public class StopEnemiesOnGameOver : ReactiveSystem<GameEntity>
  {
    private readonly List<GameEntity> _buffer = new (128);
    private readonly IGroup<GameEntity> _enemies;

    public StopEnemiesOnGameOver(GameContext game) : base(game)
    {
      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy, 
          GameMatcher.Moving));
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.GameOver.Added());

    protected override bool Filter(GameEntity gameover) => gameover.isGameOver;

    protected override void Execute(List<GameEntity> entities)
    {
      foreach (GameEntity enemy in _enemies.GetEntities(_buffer))
      {
        enemy.isMoving = false;
      }
    }
  }
}