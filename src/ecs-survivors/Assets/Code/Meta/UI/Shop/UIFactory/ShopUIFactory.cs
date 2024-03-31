using Code.Infrastructure.AssetManagement;
using Code.Meta.UI.Shop.Items;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.Shop.UIFactory
{
  public class ShopUIFactory : IShopUIFactory
  {
    private readonly IAssetProvider _assetProvider;
    private readonly IInstantiator _instantiator;

    private const string ShopItemPrefabPath = "UI/Home/Shop/ShopItem";

    public ShopUIFactory(IInstantiator instantiator, IAssetProvider assetProvider)
    {
      _instantiator = instantiator;
      _assetProvider = assetProvider;
    }

    public ShopItem CreateShopItem(ShopItemConfig config, Transform at)
    {
      ShopItem shopItemPrefab = _assetProvider.LoadAsset<ShopItem>(ShopItemPrefabPath);
      ShopItem item = _instantiator.InstantiatePrefabForComponent<ShopItem>(shopItemPrefab, at);

      item.Setup(config);
      
      return item;
    }
  }
}