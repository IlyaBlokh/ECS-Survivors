using Code.Common.Extensions;
using Code.Gameplay.Cameras.Provider;
using Code.Gameplay.Common;
using Code.Gameplay.Common.Time;
using Code.Gameplay.Features.Enemies.Factory;
using Code.Gameplay.Features.Enemies.Services;
using Entitas;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code.Gameplay.Features.Enemies.Systems
{
  public class EnemySpawnSystem : IExecuteSystem
  {
    private const float SpawnDistanceGap = 1f;

    private readonly IEnemyFactory _enemyFactory;
    private readonly IWaveCounter _waveCounter;
    private readonly ICameraProvider _cameraProvider;
    private readonly ITimeService _time;

    private readonly IGroup<GameEntity> _timers;
    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _enemyUnlocks;

    public EnemySpawnSystem(
      GameContext game, 
      ITimeService time, 
      IEnemyFactory enemyFactory, 
      IWaveCounter waveCounter,
      ICameraProvider cameraProvider)
    {
      _waveCounter = waveCounter;
      _enemyFactory = enemyFactory;
      _cameraProvider = cameraProvider;
      _time = time;

      _timers = game.GetGroup(GameMatcher.SpawnTimer);
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
      
      _enemyUnlocks = game.GetGroup(GameMatcher.EnemyTypes);
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes)
      foreach (GameEntity timer in _timers) 
      foreach (GameEntity enemyUnlock in _enemyUnlocks)
      {
        timer.ReplaceSpawnTimer(timer.SpawnTimer - _time.DeltaTime);
        if (timer.SpawnTimer <= 0)
        {
          _enemyFactory.CreateRandomEnemy(enemyUnlock.EnemyTypes, at: RandomSpawnPosition(hero.WorldPosition));
          timer.ReplaceSpawnTimer(_waveCounter.TimerAfterEnemySpawn());
        }
      }
    }
    
    private Vector2 RandomSpawnPosition(Vector2 heroWorldPosition)
    {
      bool startWithHorizontal = Random.Range(0, 2) == 0;

      return startWithHorizontal 
        ? HorizontalSpawnPosition(heroWorldPosition) 
        : VerticalSpawnPosition(heroWorldPosition);
    }

    private Vector2 HorizontalSpawnPosition(Vector2 heroWorldPosition)
    {
      Vector2[] horizontalDirections = { Vector2.left, Vector2.right };
      Vector2 primaryDirection = horizontalDirections.PickRandom();
      
      float horizontalOffsetDistance = _cameraProvider.WorldScreenWidth / 2 + SpawnDistanceGap;
      float verticalRandomOffset = Random.Range(-_cameraProvider.WorldScreenHeight / 2, _cameraProvider.WorldScreenHeight / 2);

      return heroWorldPosition + primaryDirection * horizontalOffsetDistance + Vector2.up * verticalRandomOffset;
    }

    private Vector2 VerticalSpawnPosition(Vector2 heroWorldPosition)
    {
      Vector2[] verticalDirections = { Vector2.up, Vector2.down };
      Vector2 primaryDirection = verticalDirections.PickRandom();
      
      float verticalOffsetDistance = _cameraProvider.WorldScreenHeight / 2 + SpawnDistanceGap;
      float horizontalRandomOffset = Random.Range(-_cameraProvider.WorldScreenWidth / 2, _cameraProvider.WorldScreenWidth / 2);

      return heroWorldPosition + primaryDirection * verticalOffsetDistance + Vector2.right * horizontalRandomOffset;
    }
  }
}