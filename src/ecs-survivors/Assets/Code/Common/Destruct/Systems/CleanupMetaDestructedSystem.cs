using System.Collections.Generic;
using Entitas;

namespace Code.Common.Destruct.Systems
{
  public class CleanupMetaDestructedSystem : ICleanupSystem
  {
    private readonly IGroup<MetaEntity> _entities;
    private readonly List<MetaEntity> _buffer = new (16);

    public CleanupMetaDestructedSystem(MetaContext metaContext) => 
      _entities = metaContext.GetGroup(MetaMatcher.Destructed);

    public void Cleanup()
    {
      foreach (MetaEntity entity in _entities.GetEntities(_buffer)) 
        entity.Destroy();
    }
  }
}