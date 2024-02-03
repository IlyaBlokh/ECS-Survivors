using System.Collections.Generic;
using Code.Gameplay.Common.Time;
using Entitas;

namespace Code.Common.Destruct.Systems
{
  public class SelfDestructTimerSystem : IExecuteSystem
  {
    private readonly ITimeService _time;
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new (64);

    public SelfDestructTimerSystem(GameContext game, ITimeService time)
    {
      _time = time;
      _entities = game.GetGroup(GameMatcher.SelfDestructTimer);
    }
    
    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.SelfDestructTimer > 0)
          entity.ReplaceSelfDestructTimer(entity.SelfDestructTimer - _time.DeltaTime);
        else
        {
          entity.RemoveSelfDestructTimer();
          entity.isDestructed = true;
        }
      }
    }
  }
}