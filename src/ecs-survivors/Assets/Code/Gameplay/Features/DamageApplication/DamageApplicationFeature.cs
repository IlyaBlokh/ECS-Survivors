using Code.Gameplay.Features.DamageApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.DamageApplication
{
  public class DamageApplicationFeature : Feature
  {
    public DamageApplicationFeature(ISystemFactory systems)
    {
      Add(systems.Create<ApplyDamageOnTargetsSystem>());
      
      Add(systems.Create<DestructOnZeroHPSystem>());
    }
  }
}