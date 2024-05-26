using Code.Gameplay.Features.LevelUp.Services;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class CollectExperienceSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _collected;
    private readonly IGroup<GameEntity> _heroes;
    private readonly ILevelUpService _levelUpService;

    public CollectExperienceSystem(GameContext game, ILevelUpService levelUpService)
    {
      _levelUpService = levelUpService;
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Experience));
      
      _collected = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collected,
          GameMatcher.Experience));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes) 
      foreach (GameEntity collected in _collected)
      {
        _levelUpService.AddExperience(collected.Experience);
        hero.ReplaceExperience(_levelUpService.CurrentExperience);
      }
    }
  }
}