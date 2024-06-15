using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Enchants;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems.StatusVisuals
{
  public class ApplyMetamorphVisualsSystem : ReactiveSystem<GameEntity> 
  {
    private IStaticDataService _staticDataService;

    public ApplyMetamorphVisualsSystem(GameContext game, IStaticDataService staticDataService) : base(game)
    {
      _staticDataService = staticDataService;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
      context.CreateCollector(GameMatcher.Metamorph.Added());

    protected override bool Filter(GameEntity entity) => entity.isStatus && entity.isMetamorph && entity.hasTargetId;

    protected override void Execute(List<GameEntity> statuses)
    {
      foreach (GameEntity status in statuses)
      {
        GameEntity target = status.Target();
        if (target is {hasStatusVisuals: true}) 
          target.StatusVisuals.ApplyMetamorph(_staticDataService.GetEnchantConfig(EnchantTypeId.HexArmaments).Image);
      }
    }
  }
}