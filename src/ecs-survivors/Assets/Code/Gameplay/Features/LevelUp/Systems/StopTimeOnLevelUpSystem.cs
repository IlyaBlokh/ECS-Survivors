using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Windows;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
  public class StopTimeOnLevelUpSystem : ReactiveSystem<GameEntity>
  {
    private ITimeService _time;

    public StopTimeOnLevelUpSystem(GameContext game, ITimeService time) : base(game)
    {
      _time = time;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher.LevelUp.Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> levelUps)
    {
      _time.StopTime();
    }
  }
}