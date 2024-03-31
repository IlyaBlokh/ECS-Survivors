using Code.Common.Destruct;
using Code.Infrastructure.Systems;
using Code.Meta.Features.Simulation;
using Code.Meta.Features.Simulation.Systems;
using Code.Progress;

namespace Code.Meta
{
  public class HomeScreenFeature : Feature
  {
    public HomeScreenFeature(ISystemFactory systems)
    {
      Add(systems.Create<EmitTickSystem>(MetaConstants.SimulationTickSeconds));
      
      Add(systems.Create<SimulationFeature>());
      
      Add(systems.Create<HomeUIFeature>());
      
      Add(systems.Create<PeriodicallySaveProgressSystem>(MetaConstants.SaveProgressPeriodSeconds));
      
      Add(systems.Create<CleanupTickSystem>());
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}