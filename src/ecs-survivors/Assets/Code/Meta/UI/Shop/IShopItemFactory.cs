using Code.Meta.UI.Shop.Items;

namespace Code.Meta.UI.Shop
{
  public interface IShopItemFactory
  {
    MetaEntity CreateShopItem(ShopItemId shopItemId);
  }
}