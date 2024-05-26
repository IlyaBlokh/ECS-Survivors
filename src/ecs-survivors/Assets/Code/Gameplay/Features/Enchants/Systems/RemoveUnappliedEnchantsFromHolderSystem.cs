using System.Collections.Generic;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
  public class RemoveUnappliedEnchantsFromHolderSystem : ReactiveSystem<GameEntity>
  {
    private readonly IGroup<GameEntity> _enchantHolders;

    public RemoveUnappliedEnchantsFromHolderSystem(GameContext game) : base(game)
    {
      _enchantHolders = game.GetGroup(GameMatcher.EnchantHolder);
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId, 
          GameMatcher.Unapplied).Added());

    protected override bool Filter(GameEntity entity) => true;

    protected override void Execute(List<GameEntity> enchants)
    {
      foreach (GameEntity enchantHolder in _enchantHolders)   
      foreach (GameEntity enchant in enchants)
      {
        enchantHolder.EnchantHolder.RemoveEnchant(enchant.EnchantTypeId);
      }
    }
  }
}