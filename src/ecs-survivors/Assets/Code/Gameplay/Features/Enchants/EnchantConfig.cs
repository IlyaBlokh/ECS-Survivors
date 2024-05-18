using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants
{
  [CreateAssetMenu(menuName = "ECS Survivors/EnchantConfig", fileName = "EnchantConfig", order = 0)]
  public class EnchantConfig : ScriptableObject
  {
    public EnchantTypeId TypeId;
    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;
  }
}