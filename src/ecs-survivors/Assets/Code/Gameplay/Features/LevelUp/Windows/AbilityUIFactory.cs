using Code.Gameplay.Features.LevelUp.Behaviours;
using Code.Infrastructure.AssetManagement;
using UnityEngine;
using Zenject;

namespace Code.Gameplay.Features.LevelUp.Windows
{
  public class AbilityUIFactory : IAbilityUIFactory
  {
    private const string AbilityCardPrefabPath = "UI/Abilities/AbilityCard";
    
    private readonly IInstantiator _instantiator;
    private readonly IAssetProvider _assets;

    public AbilityUIFactory(IInstantiator instantiator, IAssetProvider assets)
    {
      _instantiator = instantiator;
      _assets = assets;
    }

    public AbilityCard CreateAbilityCard(Transform parent) =>
      _instantiator
        .InstantiatePrefabForComponent<AbilityCard>(_assets.LoadAsset<AbilityCard>(AbilityCardPrefabPath), parent);
  }
}