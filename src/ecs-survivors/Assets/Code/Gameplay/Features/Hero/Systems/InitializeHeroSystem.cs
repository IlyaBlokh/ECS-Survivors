using Code.Gameplay.Features.Hero.Factory;
using Code.Gameplay.Levels;
using Entitas;

namespace Code.Gameplay.Features.Hero.Systems
{
  public class InitializeHeroSystem : IInitializeSystem
  {
    private readonly IHeroFactory _heroFactory;
    private readonly ILevelDataProvider _levelDataProvider;

    public InitializeHeroSystem(IHeroFactory heroFactory, ILevelDataProvider levelDataProvider)
    {
      _heroFactory = heroFactory;
      _levelDataProvider = levelDataProvider;
    }
    
    public void Initialize()
    {
      _heroFactory.CreateHero(_levelDataProvider.StartPoint);
    }
  }
}