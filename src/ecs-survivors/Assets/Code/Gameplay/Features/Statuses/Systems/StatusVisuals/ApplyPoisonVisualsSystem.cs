﻿using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Statuses.Systems.StatusVisuals
{
  public class ApplyPoisonVisualsSystem : ReactiveSystem<GameEntity> 
  {
    public ApplyPoisonVisualsSystem(GameContext game) : base(game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) => 
      context.CreateCollector(GameMatcher.Poison.Added());

    protected override bool Filter(GameEntity entity) => entity.isStatus && entity.isPoison && entity.hasTargetId;

    protected override void Execute(List<GameEntity> statuses)
    {
      foreach (GameEntity status in statuses)
      {
        GameEntity target = status.Target();
        if (target is {hasStatusVisuals: true}) 
          target.StatusVisuals.ApplyPoison();
      }
    }
  }
}