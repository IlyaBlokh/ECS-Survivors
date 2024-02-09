using Code.Gameplay.Features.EffectApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.EffectApplication
{
  public class EffectApplicationFeature : Feature
  {
    public EffectApplicationFeature(ISystemFactory systems)
    {
      Add(systems.Create<ApplyEffectsOnTargetsSystem>());
      Add(systems.Create<ApplyStatusesOnTargetsSystem>());
    }
  }
}