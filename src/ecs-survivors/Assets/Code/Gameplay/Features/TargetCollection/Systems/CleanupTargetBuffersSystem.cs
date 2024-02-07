using Entitas;

namespace Code.Gameplay.Features.TargetCollection.Systems
{
  public class CleanupTargetBuffersSystem : ICleanupSystem
  {
    private readonly IGroup<GameEntity> _entities;

    public CleanupTargetBuffersSystem(GameContext game)
    {
      _entities = game.GetGroup(GameMatcher.TargetBuffer);
    }
    
    public void Cleanup()
    {
      foreach (GameEntity entity in _entities)
      {
        entity.TargetBuffer.Clear();
      }  
    }
  }
}