namespace Code.Gameplay.Features.LevelUp.Services
{
  public interface ILevelUpService
  {
    float CurrentExperience { get; }
    int CurrentLevel { get; }
    float ExperienceForLevelUp();
    void AddExperience(float exp);
  }
}