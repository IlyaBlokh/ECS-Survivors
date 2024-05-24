using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class CollectWhenNearSystem : IExecuteSystem
  {
    private const float CloseDistance = 0.1f;
    private readonly IGroup<GameEntity> _pullables;
    private readonly IGroup<GameEntity> _heroes;
    private readonly List<GameEntity> _buffer = new(128);

    public CollectWhenNearSystem(GameContext game)
    {
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
      
      _pullables = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Pulling,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes) 
        foreach (GameEntity pullable in _pullables.GetEntities(_buffer))
        {
          if (Vector3.SqrMagnitude(hero.WorldPosition - pullable.WorldPosition) < CloseDistance) 
            pullable.isCollected = true;
        }
    }
  }
}