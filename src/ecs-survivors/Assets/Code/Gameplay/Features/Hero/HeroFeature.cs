using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Features.Hero.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Hero
{
  public sealed class HeroFeature : Feature
  {
    public HeroFeature(ISystemFactory systems)
    {
      Add(systems.Create<InitializeHeroSystem>());
      
      Add(systems.Create<SetHeroDirectionByInputSystem>());
      Add(systems.Create<CameraFollowHeroSystem>());
      Add(systems.Create<AnimateHeroMovementSystem>());
      Add(systems.Create<HeroDeathSystem>());
      
      Add(systems.Create<FinalizeHeroDeathProcessingSystem>());
    }
  }
}