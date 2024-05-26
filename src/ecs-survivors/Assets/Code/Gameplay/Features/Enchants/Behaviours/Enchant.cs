using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
  public class Enchant : MonoBehaviour
  {
    public EnchantTypeId Id;
    public Image Icon;

    public void Set(EnchantConfig config)
    {
      Id = config.TypeId;
      Icon.sprite = config.Icon;
    }
  }
}