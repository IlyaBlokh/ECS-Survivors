using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Effects.Systems
{
  public class ProcessHealEffectSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _effects;

    public ProcessHealEffectSystem(GameContext game)
    {
      _effects = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.HealEffect,
          GameMatcher.EffectValue,
          GameMatcher.TargetId));
    }

    public void Execute()
    {
      foreach (GameEntity effect in _effects)
      {
        GameEntity target = effect.Target();

        effect.isProcessed = true;
       
        if (target.isDead)
          continue;

        if (target.hasCurrentHp && target.hasMaxHp)
        {
          float newValue = Mathf.Min(target.CurrentHp + effect.EffectValue, target.MaxHp);
          target.ReplaceCurrentHp(newValue);
        }
      }
    }
  }
}