using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems
{
  public class PeriodicHealStatusSystem : IExecuteSystem
  {
    private readonly ITimeService _timeService;
    private readonly IEffectFactory _effectFactory;
    private readonly IGroup<GameEntity> _statuses;

    public PeriodicHealStatusSystem(GameContext game, ITimeService timeService, IEffectFactory effectFactory)
    {
      _timeService = timeService;
      _effectFactory = effectFactory;
      _statuses = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Status,
          GameMatcher.Period,
          GameMatcher.TimeSinceLastTick,
          GameMatcher.EffectValue,
          GameMatcher.ProducerId,
          GameMatcher.TargetId,
          GameMatcher.Healing));
    }

    public void Execute()
    {
      foreach (GameEntity status in _statuses)
      {
        if (status.TimeSinceLastTick >= 0)
          status.ReplaceTimeSinceLastTick(status.TimeSinceLastTick - _timeService.DeltaTime);
        else
        {
          status.ReplaceTimeSinceLastTick(status.Period);
          
          _effectFactory.CreateEffect(new EffectSetup {EffectTypeId = EffectTypeId.Heal, Value = status.EffectValue},
            status.ProducerId,
            status.TargetId);
        }
      }
    }
  }
}