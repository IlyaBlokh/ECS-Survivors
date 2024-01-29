using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Cameras.Systems;
using Code.Gameplay.Features.Hero.Systems;

namespace Code.Gameplay.Features.Hero
{
  public class HeroFeature : Feature
  {
    public HeroFeature(GameContext gameContext, ICameraProvider cameraProvider)
    {
      Add(new SetHeroDirectionByInputSystem(gameContext));
      
      Add(new CameraFollowHeroSystem(gameContext, cameraProvider));
      Add(new AnimateHeroMovementSystem(gameContext));
    }
  }
}