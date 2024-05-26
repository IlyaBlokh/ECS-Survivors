using Code.Gameplay.Features.Enchants.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants.UIFactories
{
  public interface IEnchantUIFactory
  {
    Enchant CreateEnchant(Transform parent, EnchantTypeId typeId);
  }
}