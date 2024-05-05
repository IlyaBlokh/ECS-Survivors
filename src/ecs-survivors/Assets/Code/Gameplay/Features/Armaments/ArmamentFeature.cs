using Code.Gameplay.Features.Armaments.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Armaments
{
  public class ArmamentFeature : Feature
  {
    public ArmamentFeature(ISystemFactory systems)
    {
      Add(systems.Create<MarkProcessedOnTargetLimitExceededSystem>());
      Add(systems.Create<FinalizeProcessedArmamentsSystem>());
    }
  }
}