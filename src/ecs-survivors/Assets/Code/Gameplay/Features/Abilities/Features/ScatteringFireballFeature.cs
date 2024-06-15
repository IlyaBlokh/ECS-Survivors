using Code.Gameplay.Features.Abilities.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities.Features
{
  public sealed class ScatteringFireballFeature : Feature
  {
    public ScatteringFireballFeature(ISystemFactory systems)
    {
      Add(systems.Create<LaunchScatteringFireballAbilitySystem>());
      Add(systems.Create<ScheduledProcessForScatteringFireballSystem>());
    }
  }
}