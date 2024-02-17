using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UIFactory;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
  public class EnchantHolder : MonoBehaviour
  {
    public Transform EnchantsLayout;

    private readonly List<Enchant> _enchants = new();
    private IEnchantUIFactory _factory;

    [Inject]
    private void Construct(IEnchantUIFactory factory)
    {
      _factory = factory;
    }

    public void AddEnchant(EnchantTypeId enchantType)
    {
      if (EnchantIsAlreadyHeld(enchantType))
        return;
      
      Enchant enchant = _factory.CreateEnchant(EnchantsLayout, enchantType);
      
      _enchants.Add(enchant);
    }

    public void RemoveEnchant(EnchantTypeId enchantType)
    {
      Enchant enchant = _enchants.Find(enchant => enchant.Id == enchantType);
      if (enchant != null)
      {
        _enchants.Remove(enchant);
        Destroy(enchant.gameObject);
      }
    }

    private bool EnchantIsAlreadyHeld(EnchantTypeId enchantType) => 
      _enchants.Find(enchant => enchant.Id == enchantType) != null;
  }
}