using Code.Gameplay.Features.DamageApplication.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.DamageApplication
{
  public sealed class DeathFeature : Feature
  {
    public DeathFeature(ISystemFactory systems)
    {
      Add(systems.Create<MarkDeadSystem>());
    }
  }
}