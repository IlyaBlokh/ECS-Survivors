using Entitas;

namespace Code.Gameplay.Features.Effects.Systems
{
  public class RemoveEffectsWithoutTargetsSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _effects;

    public RemoveEffectsWithoutTargetsSystem(GameContext game)
    {
      _effects = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Effect,
          GameMatcher.TargetId));
    }

    public void Execute()
    {
      foreach (GameEntity effect in _effects)
      {
        GameEntity target = effect.Target();
        if (target == null)
          effect.Destroy();
      }
    }
  }
}