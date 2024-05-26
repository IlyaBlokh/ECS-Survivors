using System.Collections.Generic;
using Code.Gameplay.Features.Enchants.UIFactories;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.Behaviours
{
  public class EnchantHolder : MonoBehaviour
  {
    public Transform EnchantLayout;
    
    private IEnchantUIFactory _enchantUIFactory;
    private readonly List<Enchant> _enchants = new();

    [Inject]
    private void Construct(IEnchantUIFactory enchantUIFactory)
    {
      _enchantUIFactory = enchantUIFactory;
    }
    
    public void AddEnchant(EnchantTypeId typeId)
    {
      if (EnchantAlreadyHeld(typeId))
        return;
      
      Enchant enchant = _enchantUIFactory.CreateEnchant(EnchantLayout, typeId);
      _enchants.Add(enchant);
    }

    public void RemoveEnchant(EnchantTypeId typeId)
    {
      Enchant enchant = _enchants.Find(x => x.Id == typeId);
      if (enchant != null)
      {
        _enchants.Remove(enchant);
        Destroy(enchant.gameObject);
      }
    }

    private bool EnchantAlreadyHeld(EnchantTypeId typeId) => 
      _enchants.Find(x => x.Id == typeId) != null;
  }
}