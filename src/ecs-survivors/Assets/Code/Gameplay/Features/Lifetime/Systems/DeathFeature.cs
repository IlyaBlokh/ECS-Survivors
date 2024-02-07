using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Lifetime.Systems
{
  public sealed class DeathFeature : Feature
  {
    public DeathFeature(ISystemFactory systems)
    {
      Add(systems.Create<MarkDeadSystem>());
    }
  }
}