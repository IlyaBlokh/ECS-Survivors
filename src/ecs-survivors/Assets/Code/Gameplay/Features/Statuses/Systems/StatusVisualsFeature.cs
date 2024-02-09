using Code.Gameplay.Features.Statuses.Systems.StatusVisuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses.Systems
{
  public class StatusVisualsFeature : Feature
  {
    public StatusVisualsFeature(ISystemFactory systems)
    {
      Add(systems.Create<ApplyPoisonVisualsSystem>());
      Add(systems.Create<UnapplyPoisonVisualsSystem>());
    }
  }
}