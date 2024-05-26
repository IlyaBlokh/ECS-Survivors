using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
  public class AddEnchantsToHolderSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enchantHolders;
    private readonly IGroup<GameEntity> _enchants;

    public AddEnchantsToHolderSystem(GameContext game)
    {
      _enchantHolders = game.GetGroup(GameMatcher.EnchantHolder);
      _enchants = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId,
          GameMatcher.TimeLeft));
    }

    public void Execute()
    {
      foreach (GameEntity enchantHolder in _enchantHolders)
        foreach (GameEntity enchant in _enchants)
        {
          enchantHolder.EnchantHolder.AddEnchant(enchant.EnchantTypeId);
        }
    }
  }
}