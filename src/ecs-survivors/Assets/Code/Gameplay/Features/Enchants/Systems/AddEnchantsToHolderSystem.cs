using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
  public class AddEnchantsToHolderSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _holders;
    private readonly IGroup<GameEntity> _enсhants;

    public AddEnchantsToHolderSystem(GameContext game)
    {
      _holders = game.GetGroup(GameMatcher
        .AllOf(GameMatcher.EnchantsHolder));

      _enсhants = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId,
          GameMatcher.TimeLeft));
    }

    public void Execute()
    {
      foreach (GameEntity holder in _holders)
      foreach (GameEntity enchant in _enсhants)
        holder.EnchantsHolder.AddEnchant(enchant.EnchantTypeId);
    }
  }
}