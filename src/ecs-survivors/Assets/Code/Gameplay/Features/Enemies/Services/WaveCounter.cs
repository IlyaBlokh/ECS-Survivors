using Code.Gameplay.Features.LevelUp.Services;
using Code.Gameplay.StaticData;

namespace Code.Gameplay.Features.Enemies.Services
{
  public class WaveCounter : IWaveCounter
  {
    private const float InsideWavePause = 0.25f;
    private const float BetweenWavePause = 3f;
    
    private readonly IStaticDataService _staticDataService;
    private readonly ILevelUpService _levelUpService;
    private int _spawnedInWave;

    public WaveCounter(IStaticDataService staticDataService, ILevelUpService levelUpService)
    {
      _staticDataService = staticDataService;
      _levelUpService = levelUpService;
    }

    public float TimerAfterEnemySpawn()
    {
      int totalInWave = _staticDataService.EnemyInWaveForLevel(_levelUpService.CurrentLevel);
      _spawnedInWave++;
      if (_spawnedInWave < totalInWave)
        return InsideWavePause;
      else
      {
        _spawnedInWave = 0;
        return BetweenWavePause;
      }
    }
  }
}