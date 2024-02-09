using Code.Gameplay.Features.Statuses;
using Code.Gameplay.Features.Statuses.Applier;
using Entitas;

namespace Code.Gameplay.Features.EffectApplication.Systems
{
  public class ApplyStatusesOnTargetsSystem : IExecuteSystem
  {
    private readonly IStatusApplier _statusApplier;
    private readonly IGroup<GameEntity> _entities;

    public ApplyStatusesOnTargetsSystem(GameContext game, IStatusApplier statusApplier)
    {
      _statusApplier = statusApplier;
      _entities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.TargetBuffer,
          GameMatcher.StatusSetups));
    }
    
    public void Execute()
    {
      foreach (GameEntity entity in _entities)
      foreach (int targetId in entity.TargetBuffer)
      foreach (StatusSetup setup in entity.StatusSetups)
      {
        _statusApplier.ApplyStatus(setup, ProducerId(entity), targetId);
      }
    }

    private static int ProducerId(GameEntity entity)
    {
      return entity.hasProducerId ? entity.ProducerId : entity.Id;
    }
  }
}