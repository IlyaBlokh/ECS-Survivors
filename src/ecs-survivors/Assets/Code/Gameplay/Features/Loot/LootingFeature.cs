using Code.Gameplay.Features.LevelUp.Systems;
using Code.Gameplay.Features.Loot.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Loot
{
  public sealed class LootingFeature : Feature
  {
    public LootingFeature(ISystemFactory systems)
    {
      Add(systems.Create<CastForPullablesSystem>());
      
      Add(systems.Create<PullTowardsHeroSystem>());
      Add(systems.Create<CollectWhenNearSystem>());
      
      Add(systems.Create<CollectExperienceSystem>());
      Add(systems.Create<CollectEffectItemSystem>());
      Add(systems.Create<CollectStatusItemSystem>());
      
      Add(systems.Create<UpdateExperienceMeterSystem>());
      
      Add(systems.Create<CleanupCollected>());
    }
  }

}