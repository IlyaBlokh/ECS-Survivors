using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
  public class MarkDeadSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _entities;
    private readonly List<GameEntity> _buffer = new(128);

    public MarkDeadSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.CurrentHP, 
          GameMatcher.MaxHP)
        .NoneOf(GameMatcher.Dead));
    }

    public void Execute()
    {
      foreach (GameEntity entity in _entities.GetEntities(_buffer))
      {
        if (entity.CurrentHP <= 0)
        {
          Debug.Log($"mark dead: {entity.Id}");
          entity.isDead = true;
          entity.isProcessingDeath = true;
        }
      }
    }
  }
}