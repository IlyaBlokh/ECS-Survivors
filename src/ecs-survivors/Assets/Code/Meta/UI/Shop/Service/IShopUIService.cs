using System;
using System.Collections.Generic;
using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop.Service
{
  public interface IShopUIService
  {
    event Action ShopChanged;
    List<ShopItemConfig> GetAvailableShopItems { get; }
    
    ShopItemConfig GetConfig(ShopItemId shopItemId);
    void UpdatePurchasedItems(IEnumerable<ShopItemId> purchasedItems);
    void UpdatePurchasedItem(ShopItemId shopItemId);
    void Cleanup();
  }
}