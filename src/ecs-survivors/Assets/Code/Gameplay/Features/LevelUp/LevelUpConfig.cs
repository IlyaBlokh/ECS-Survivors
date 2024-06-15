using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
  [CreateAssetMenu(menuName = "ECS Survivors/LevelUpConfig", fileName = "LevelUpConfig", order = 0)]
  public class LevelUpConfig : ScriptableObject
  {
    public int MaxLevel;
    public List<float> ExperienceForLevel;
  }
}