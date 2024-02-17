using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants
{
  [CreateAssetMenu(menuName = "ECS Survivors/Enchant Config", fileName = "enchantConfig")]
  public class EnchantConfig : ScriptableObject
  {
    public EnchantTypeId TypeId;

    public Sprite Icon;
    
    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;
    
    public float Radius;
    public EntityBehaviour ViewPrefab;
  }
}