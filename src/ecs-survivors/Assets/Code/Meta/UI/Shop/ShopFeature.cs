using Code.Infrastructure.Systems;
using Code.Meta.UI.Shop.Systems;

namespace Code.Meta.UI.Shop
{
  public sealed class ShopFeature : Feature
  {
    public ShopFeature(ISystemFactory systems)
    {
      Add(systems.Create<BuyItemOnRequestSystem>());
      Add(systems.Create<ProcessBoughtItemsSystem>());
    }
  }
}