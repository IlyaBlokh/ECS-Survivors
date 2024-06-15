using Code.Gameplay.Features.Lifetime.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime
{
  public sealed class DeathFeature : Feature
  {
    public DeathFeature(ISystemFactory systems)
    {
      Add(systems.Create<MarkDeadSystem>());
      Add(systems.Create<UnapplyStatusesOfDeadTargetSystem>());
    }
  }
}