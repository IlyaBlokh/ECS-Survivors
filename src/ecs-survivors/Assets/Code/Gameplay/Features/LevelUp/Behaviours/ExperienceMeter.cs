using UnityEngine;
using UnityEngine.UI;

namespace Code.Gameplay.Features.LevelUp.Behaviours
{
  public class ExperienceMeter : MonoBehaviour
  {
    public Slider ProgressBar;
    public Image Fill;
    
    public void SetExperience(float heroExperience, float experienceForLevelUp)
    {
      Fill.type = Image.Type.Tiled;
      ProgressBar.value = heroExperience / experienceForLevelUp;
    }
  }
}