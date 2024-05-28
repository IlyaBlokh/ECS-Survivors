using Code.Gameplay.Features.Statuses.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Statuses
{
  public sealed class StatusFeature : Feature
  {
    public StatusFeature(ISystemFactory systems)
    {
      Add(systems.Create<StatusDurationSystem>());
      Add(systems.Create<PeriodicPoisonDamageStatusSystem>());
      Add(systems.Create<PeriodicHealStatusSystem>());
      Add(systems.Create<ApplyFreezeStatusSystem>());
      Add(systems.Create<ApplySpeedChangeStatusSystem>());
      
      Add(systems.Create<StatusVisualsFeature>());
      
      Add(systems.Create<CleanupUnappliedStatusLinkedChanges>());
      Add(systems.Create<CleanupUnappliedStatuses>());
    }
  }
}