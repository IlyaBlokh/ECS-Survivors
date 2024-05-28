using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
  public class StartTimeOnLevelUpProcessedSystem : ReactiveSystem<GameEntity>
  {
    private ITimeService _time;

    public StartTimeOnLevelUpProcessedSystem(GameContext game, ITimeService time) : base(game)
    {
      _time = time;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.Processed.Added());

    protected override bool Filter(GameEntity entity) => entity.isLevelUp && entity.isProcessed;

    protected override void Execute(List<GameEntity> levelUps)
    {
      _time.StartTime();
    }
  }
}