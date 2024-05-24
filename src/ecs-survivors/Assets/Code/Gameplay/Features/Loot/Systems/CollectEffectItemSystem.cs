using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Effects.Factory;
using Entitas;

namespace Code.Gameplay.Features.Loot.Systems
{
  public class CollectEffectItemSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _collected;
    private readonly IGroup<GameEntity> _heroes;
    private readonly IEffectFactory _effectFactory;

    public CollectEffectItemSystem(GameContext game, IEffectFactory effectFactory)
    {
      _effectFactory = effectFactory;
      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.Id,
          GameMatcher.WorldPosition));
      
      _collected = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Collected,
          GameMatcher.EffectSetups));
    }

    public void Execute()
    {
      foreach (GameEntity hero in _heroes) 
      foreach (GameEntity collected in _collected)
      foreach (EffectSetup effectSetup in collected.EffectSetups)
        _effectFactory.CreateEffect(effectSetup, hero.Id, hero.Id);
    }
  }
}