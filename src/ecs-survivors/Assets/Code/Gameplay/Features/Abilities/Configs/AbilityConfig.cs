﻿using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [CreateAssetMenu(menuName = "ECS Survivors", fileName = "AbilityConfig")]
  public class AbilityConfig : ScriptableObject
  {
    public AbilityId AbilityId;
    public List<AbilityLevel> Levels;
    public int KillsToUnlock;
  }
}