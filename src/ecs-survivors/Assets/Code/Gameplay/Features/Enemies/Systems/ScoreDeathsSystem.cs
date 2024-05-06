using Code.Gameplay.Features.Lifetime;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Systems
{
  public class ScoreDeathsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enemies;
    private readonly IGroup<GameEntity> _heroes;

    public ScoreDeathsSystem(GameContext game)
    {
      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.Dead,
          GameMatcher.ProcessingDeath));
      
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.KillScore));
    }

    public void Execute()
    {
      foreach (GameEntity enemy in _enemies)
        foreach (GameEntity hero in _heroes)
        {
          hero.ReplaceKillScore(hero.KillScore + 1);
          Debug.Log($"kills:{hero.KillScore}");
        }
    }
  }
}