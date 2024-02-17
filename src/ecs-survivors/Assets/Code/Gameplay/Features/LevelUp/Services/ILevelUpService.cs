namespace Code.Gameplay.Features.LevelUp.Services
{
  public interface ILevelUpService
  {
    float CurrentExperience { get; }
    int CurrentLevel { get; }
    float ExperienceForLevelUp { get; }
    void AddExperience(float value);
  }
}