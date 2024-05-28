using Code.Gameplay.Features.Enchants.Systems;
using Code.Gameplay.Features.Statuses.Systems.StatusVisuals;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses.Systems
{
  public class StatusVisualsFeature : Feature
  {
    public StatusVisualsFeature(ISystemFactory systems)
    {
      Add(systems.Create<ApplyPoisonVisualsSystem>());
      Add(systems.Create<ApplyFreezeVisualsSystem>());
      Add(systems.Create<ApplyMetamorphVisualsSystem>());
      
      Add(systems.Create<UnapplyPoisonVisualsSystem>());
      Add(systems.Create<UnapplyFreezeVisualsSystem>());
      Add(systems.Create<UnapplyMetamorphVisualsSystem>());

      Add(systems.Create<RemoveUnappliedEnchantsFromHolderSystem>());
    }
  }
}