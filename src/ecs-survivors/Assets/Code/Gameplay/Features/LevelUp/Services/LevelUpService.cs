using Code.Common.Entity;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.LevelUp.Services
{
  public class LevelUpService : ILevelUpService
  {
    private readonly IStaticDataService _staticDataService;

    public float CurrentExperience { get; private set; }
    public int CurrentLevel { private set; get; }

    public LevelUpService(IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
    }

    public void AddExperience(float exp)
    {
      CurrentExperience += exp;
      UpdateLevel();
    }

    public float ExperienceForLevelUp()
    {
      return _staticDataService.ExperienceForLevel(CurrentLevel + 1);
    }

    private void UpdateLevel()
    {
      if (CurrentLevel >= _staticDataService.MaxLevel())
        return;

      float experienceForLevelUp = _staticDataService.ExperienceForLevel(CurrentLevel + 1);
      if (CurrentExperience < experienceForLevelUp)
        return;

      CurrentExperience -= experienceForLevelUp;
      CurrentLevel++;

      CreateEntity.Empty()
        .isLevelUp = true;
      
      UpdateLevel();
    }
  }
}