using Code.Progress.Provider;
using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
  public class UpdateSimulationTimeSystem : IExecuteSystem
  {
    private readonly IProgressProvider _progressProvider;
    private readonly IGroup<MetaEntity> _tick;

    public UpdateSimulationTimeSystem(MetaContext meta, IProgressProvider progressProvider)
    {
      _progressProvider = progressProvider;
      _tick = meta.GetGroup(MetaMatcher.Tick);
    }

    public void Execute()
    {
      foreach (MetaEntity tick in _tick)
      {
        _progressProvider.ProgressData.LastSimulationTickTime =
          _progressProvider.ProgressData.LastSimulationTickTime
            .AddSeconds(tick.Tick);
      }
    }
  }
}