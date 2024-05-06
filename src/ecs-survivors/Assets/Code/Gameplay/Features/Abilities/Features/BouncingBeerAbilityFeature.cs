using Code.Gameplay.Features.Abilities.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities.Features
{
  public sealed class BouncingBeerAbilityFeature : Feature
  {
    public BouncingBeerAbilityFeature(ISystemFactory systems)
    {
      Add(systems.Create<BouncingBeerLaunchSystem>());
      Add(systems.Create<ScheduledProcessForBouncingBeerSystem>());
      Add(systems.Create<OrientToNextNearestEnemy>());
    }
  }
}