using Code.Gameplay.Features.Enchants.Behaviours;
using Code.Gameplay.StaticData;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.Enchants.UIFactories
{
  public class EnchantUIFactory : IEnchantUIFactory
  {
    private const string EnchantPrefabPath = "UI/Enchants/Enchant";
    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assets;
    private readonly IStaticDataService _staticData;

    public EnchantUIFactory(IInstantiator instantiator, IAssetProvider assets, IStaticDataService staticData)
    {
      _instantiator = instantiator;
      _assets = assets;
      _staticData = staticData;
    }

    public Enchant CreateEnchant(Transform parent, EnchantTypeId typeId)
    {
      EnchantConfig config = _staticData.GetEnchantConfig(typeId);
      Enchant enchant = _instantiator.InstantiatePrefabForComponent<Enchant>(_assets.LoadAsset<Enchant>(EnchantPrefabPath), parent);
      enchant.Set(config);
      return enchant;
    }
  }
}