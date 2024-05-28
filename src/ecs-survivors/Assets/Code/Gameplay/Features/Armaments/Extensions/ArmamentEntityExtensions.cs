using System.Collections.Generic;
using Code.Common.Extensions;

namespace Code.Gameplay.Features.Armaments.Extensions
{
  public static class ArmamentEntityExtensions
  {
    private const int TargetBufferCapacity = 16;

    public static GameEntity AddTargetCollecting(this GameEntity entity)
    {
      return entity
        .AddTargetBuffer(new List<int>(TargetBufferCapacity))
        .AddProcessedTargets(new List<int>(TargetBufferCapacity))
        .With(x => x.isCollectingTargetsContinuously = true);
    }    
    
    public static GameEntity AddProducerFollow(this GameEntity entity, int producerId)
    {
      return entity
        .AddProducerId(producerId)
        .With(x => x.isFollowingProducer = true);
    }
  }
}