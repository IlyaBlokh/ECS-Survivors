using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Common.Physics;
using Code.Gameplay.Common.Random;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class OrientToNextNearestEnemy : IExecuteSystem
  {
    private const float CircleCastRadius = 10f;
    private readonly IPhysicsService _physicsService;
    private readonly IRandomService _random;
    private readonly IGroup<GameEntity> _armaments;
    private readonly IGroup<GameEntity> _enemies;
    private readonly List<GameEntity> _buffer = new(16);

    public OrientToNextNearestEnemy(GameContext game, IPhysicsService physicsService, IRandomService random)
    {
      _random = random;
      _physicsService = physicsService;
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament,
          GameMatcher.WorldPosition,
          GameMatcher.RequiresNextNearestEnemy));
      
      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity armament in _armaments.GetEntities(_buffer))
      {
        armament.ReplaceDirection(DirectionToNearestEnemy(armament));
        armament.RequiresNextNearestEnemy = false;
      }
    }

    private Vector3 DirectionToNearestEnemy(GameEntity entity)
    {
      List<GameEntity> nearestNewEnemies = _physicsService
        .CircleCast(entity.WorldPosition, CircleCastRadius, entity.LayerMask)
        .Where(e => !e.ProcessedByArmaments.Contains(entity.Id))
        .ToList();
      
      return nearestNewEnemies.Count == 0 
        ? RandomDirection() 
        : (nearestNewEnemies.First().WorldPosition - entity.WorldPosition).normalized;
    }

    private Vector3 RandomDirection()
    {
      Vector3 randDirection = Vector3.zero;
      while (randDirection.sqrMagnitude == 0)
      {
        randDirection= new Vector3(_random.Range(-1, 1), _random.Range(-1, 1), 0).normalized;
      }

      return randDirection;
    }
  }
}