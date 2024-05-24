using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class CollectExperienceSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _collected;
    private readonly IGroup<GameEntity> _heroes;

    public CollectExperienceSystem(GameContext game)
    {
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
        hero.ReplaceExperience(hero.Experience + collected.Experience);
      }
    }
  }
}