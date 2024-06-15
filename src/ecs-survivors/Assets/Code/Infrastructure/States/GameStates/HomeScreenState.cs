using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.Systems;
using Code.Meta;
using Code.Meta.UI.GoldHolder.Service;
using Code.Meta.UI.Shop.Service;

namespace Code.Infrastructure.States.GameStates
{
  public class HomeScreenState : EndOfFrameExitState
  {
    private readonly ISystemFactory _systems;
    private readonly GameContext _gameContext;
    private HomeScreenFeature _homeScreenFeature;
    private readonly IStorageUIService _storage;
    private readonly IShopUIService _shopUIService;

    public HomeScreenState(
      ISystemFactory systems, 
      GameContext gameContext, 
      IStorageUIService storage,
      IShopUIService shopUIService )
    {
      _systems = systems;
      _gameContext = gameContext;
      _storage = storage;
      _shopUIService = shopUIService;
    }
    
    public override void Enter()
    {
      _homeScreenFeature = _systems.Create<HomeScreenFeature>();
      _homeScreenFeature.Initialize();
    }

    protected override void OnUpdate()
    {
      _homeScreenFeature.Execute();
      _homeScreenFeature.Cleanup();
    }

    protected override void ExitOnEndOfFrame()
    {
      _storage.Cleanup();
      _shopUIService.Cleanup();
      
      _homeScreenFeature.DeactivateReactiveSystems();
      _homeScreenFeature.ClearReactiveSystems();

      DestructEntities();
      
      _homeScreenFeature.Cleanup();
      _homeScreenFeature.TearDown();
      _homeScreenFeature = null;
    }
    
    private void DestructEntities()
    {
      foreach (GameEntity entity in _gameContext.GetEntities()) 
        entity.isDestructed = true;
    }
  }
}