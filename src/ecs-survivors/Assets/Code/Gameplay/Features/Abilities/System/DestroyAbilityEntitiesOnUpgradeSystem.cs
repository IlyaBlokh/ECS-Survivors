using Entitas;

namespace Code.Gameplay.Features.Abilities.System
{
  public class DestroyAbilityEntitiesOnUpgradeSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _upgradeRequests;
    private readonly IGroup<GameEntity> _abilities;
    private readonly GameContext _game;

    public DestroyAbilityEntitiesOnUpgradeSystem(GameContext game)
    {
      _game = game;
      _upgradeRequests = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.UpgradeRequest,
          GameMatcher.AbilityId));

      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.AbilityId,
          GameMatcher.RecreatedOnUpgrade));
    }

    public void Execute()
    {
      foreach (GameEntity request in _upgradeRequests)
        foreach (GameEntity ability in _abilities)
        {
          if (request.AbilityId == ability.AbilityId)
          {
            foreach (GameEntity entity in _game.GetEntitiesWithParentAbility(ability.AbilityId))
              entity.isDestructed = true;

            ability.isActive = false;
          }
        }
    }
  }
}