using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [CreateAssetMenu(menuName = "ECS Survivors", fileName = "abilityConfig")]
  public class AbilityConfig : ScriptableObject
  {
    public AbilityId AbilityId;
    public OwnerType[] AllowedOwners;
    public List<AbilityLevel> Levels;
  }
}