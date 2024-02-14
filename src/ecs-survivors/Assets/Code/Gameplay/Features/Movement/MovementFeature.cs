using Code.Gameplay.Features.Movement.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Movement
{
  public class MovementFeature : Feature
  {
    public MovementFeature(ISystemFactory systems)
    {
      Add(systems.Create<DirectionalDeltaMoveSystem>());
      Add(systems.Create<OrbitalDeltaMoveSystem>());
      Add(systems.Create<OrbitCenterFollowSystem>());
      
      Add(systems.Create<TurnAlongDirectionSystem>());
      
      Add(systems.Create<UpdateTransformPositionSystem>());
      Add(systems.Create<RotateAlongDirectionSystem>());
    }
  }
}