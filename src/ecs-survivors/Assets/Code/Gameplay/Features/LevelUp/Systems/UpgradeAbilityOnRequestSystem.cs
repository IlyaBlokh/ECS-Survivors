using Code.Gameplay.Features.Abilities.Upgrade;
using Entitas;

namespace Code.Gameplay.Features.LevelUp.Systems
{
  public class UpgradeAbilityOnRequestSystem : IExecuteSystem
  {
    private readonly IAbilityUpgradeService _abilityUpgradeService;
    private readonly IGroup<GameEntity> _levelUps;
    private readonly IGroup<GameEntity> _abilityUpgradeRequests;

    public UpgradeAbilityOnRequestSystem(GameContext game, IAbilityUpgradeService abilityUpgradeService)
    {
      _abilityUpgradeService = abilityUpgradeService;
      
      _levelUps = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.LevelUp));
      _abilityUpgradeRequests = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.AbilityId,
          GameMatcher.UpgradeRequest));
    }

    public void Execute()
    {
      foreach (GameEntity upgradeRequest in _abilityUpgradeRequests)
      foreach (GameEntity levelUp in _levelUps)
      {
        _abilityUpgradeService.UpgradeAbility(upgradeRequest.AbilityId);

        levelUp.isProcessed = true;
        upgradeRequest.isDestructed = true;
      }
    }
  }
}