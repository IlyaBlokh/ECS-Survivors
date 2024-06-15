using Code.Gameplay.Features.Enemies.Configs;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Enemies.Systems
{
  public class UnlockEnemyTypeSystem : IExecuteSystem
  {
    private readonly IStaticDataService _staticDataService;
    private readonly IGroup<GameEntity> _sessionTimers;
    private readonly IGroup<GameEntity> _enemyUnlocks;

    public UnlockEnemyTypeSystem(GameContext game, IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
      _sessionTimers = game.GetGroup(GameMatcher.SessionTimer);
      _enemyUnlocks = game.GetGroup(GameMatcher.EnemyTypes);
    }

    public void Execute()
    {
      foreach (GameEntity timer in _sessionTimers)
      foreach (GameEntity enemyUnlock in _enemyUnlocks)
      foreach (EnemyTypeSpawnTime spawnTime in _staticDataService.EnemyTypeSpawnTimes)
        {
          if (spawnTime.PassedTime <= timer.SessionTimer)
          {
            if (!enemyUnlock.EnemyTypes.Contains(spawnTime.TypeId))
              enemyUnlock.EnemyTypes.Add(spawnTime.TypeId);
          }
        }
    }
  }
}