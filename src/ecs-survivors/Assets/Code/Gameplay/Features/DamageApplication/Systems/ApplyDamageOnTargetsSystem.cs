using Entitas;

namespace Code.Gameplay.Features.DamageApplication.Systems
{
  public class ApplyDamageOnTargetsSystem : IExecuteSystem
  {
    private readonly GameContext _game;
    private readonly IGroup<GameEntity> _damageDealers;

    public ApplyDamageOnTargetsSystem(GameContext game)
    {
      _game = game;
      _damageDealers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetBuffer,
          GameMatcher.Damage));
    }
    
    public void Execute()
    {
      foreach (GameEntity damageDealer in _damageDealers)
      foreach (int targetId in damageDealer.TargetBuffer)
      {
        GameEntity target = _game.GetEntityWithId(targetId);
        
        if (target.hasCurrentHp)
        {
          target.ReplaceCurrentHp(target.CurrentHp - damageDealer.Damage);
          
          if(target.hasDamageTakenAnimator)
            target.DamageTakenAnimator.PlayDamageTaken();
        }
      }
    }
  }
}