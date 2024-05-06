namespace Code.Gameplay.Features.TargetCollection
{
  public static class TargetCollectionEntityExtensions
  {
    public static GameEntity RemoveTargetCollectionComponents(this GameEntity entity)
    {
      if (entity.hasTargetsBuffer)
        entity.RemoveTargetsBuffer();

      if (entity.hasCollectTargetsInterval)
        entity.RemoveCollectTargetsInterval();

      if (entity.hasCollectTargetsTimer)
        entity.RemoveCollectTargetsTimer();

      entity.isReadyToCollectTargets = false;
      
      return entity;
    }

    public static GameEntity RemoveProcessedByArmamentsComponents(this GameEntity entity)
    {
      if (entity.hasScheduledToProcessByArmaments)
        entity.RemoveScheduledToProcessByArmaments();

      if (entity.hasProcessedByArmaments)
        entity.RemoveProcessedByArmaments();

      return entity;
    }
  }
}