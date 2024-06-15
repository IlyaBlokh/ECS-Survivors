using Code.Gameplay.Features.TargetCollection.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.TargetCollection
{
  public sealed class CollectTargetsFeature : Feature
  {
    public CollectTargetsFeature(ISystemFactory systems)
    {
      Add(systems.Create<CollectTargetsIntervalSystem>());
      
      Add(systems.Create<CastForTargetsNoLimitSystem>());
      Add(systems.Create<CastForTargetsWithLimitSystem>());
      Add(systems.Create<MarkReachedOnBufferFillSystem>());
      Add(systems.Create<ArmamentCastForTargetsWithLimitSystem>());
      
      Add(systems.Create<CleanupTargetBuffersSystem>());
    }
  }
}