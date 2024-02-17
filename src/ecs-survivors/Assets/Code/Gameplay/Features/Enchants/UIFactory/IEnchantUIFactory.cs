using Code.Gameplay.Features.Enchants.Behaviours;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants.UIFactory
{
  public interface IEnchantUIFactory
  {
    Enchant CreateEnchant(Transform parent, EnchantTypeId enchantType);
  }
}