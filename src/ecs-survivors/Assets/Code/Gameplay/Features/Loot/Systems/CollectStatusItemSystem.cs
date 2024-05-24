using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class CollectStatusItemSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _collected;
    private readonly IGroup<GameEntity> _heroes;
    private readonly IStatusApplier _statusApplier;

    public CollectStatusItemSystem(GameContext game, IStatusApplier statusApplier)
    {
      _statusApplier = statusApplier;
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Id,
          GameMatcher.WorldPosition));
      
      _collected = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collected,
          GameMatcher.StatusSetups));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes) 
      foreach (GameEntity collected in _collected)
      foreach (StatusSetup statusSetup in collected.StatusSetups)
        _statusApplier.ApplyStatus(statusSetup, hero.Id, hero.Id);
    }
  }
}