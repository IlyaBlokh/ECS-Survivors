using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.Systems;

namespace Code.Meta.Features.Simulation.Systems
{
  public class EmitTickSystem : TimerExecuteSystem
  {
    private readonly float _interval;

    public EmitTickSystem(float interval, ITimeService time) : base(interval, time)
    {
      _interval = interval;
    }

    protected override void Execute()
    {
      CreateMetaEntity.Empty()
        .AddTick(_interval);
    }
  }
}