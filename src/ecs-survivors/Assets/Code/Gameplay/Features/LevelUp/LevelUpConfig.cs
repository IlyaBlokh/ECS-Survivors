using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Features.LevelUp
{
  [CreateAssetMenu(fileName = "levelUpConfig", menuName = "ECS Survivors/Level up Config")]
  public class LevelUpConfig : ScriptableObject
  {
    public int MaxLevel;
    public List<float> ExperienceForLevel;
  }
}