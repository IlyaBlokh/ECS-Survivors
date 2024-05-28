using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enchants.Systems
{
  public class ApplyPoisonEnchantVisualsSystem : ReactiveSystem<GameEntity>
  {
    public ApplyPoisonEnchantVisualsSystem(GameContext context) : base(context)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher
        .AllOf(
          GameMatcher.EnchantVisuals,
          GameMatcher.Armament,
          GameMatcher.PoisonEnchant)
        .Added());

    protected override bool Filter(GameEntity entity) => entity.isArmament && entity.hasEnchantVisuals;

    protected override void Execute(List<GameEntity> armaments)
    {
      foreach (GameEntity armament in armaments)
      {
        armament.EnchantVisuals.ApplyPoison();
      }
    }
  }
}