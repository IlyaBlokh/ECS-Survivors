using Code.Gameplay.Common.Time;
using Entitas;
using UnityEngine;

namespace Code.Gameplay.Features.Movement.Systems
{
  public class OrbitalDeltaMoveSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _movers;
    private readonly ITimeService _time;

    public OrbitalDeltaMoveSystem(GameContext game, ITimeService time)
    {
      _time = time;
      _movers = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.OrbitPhase, 
          GameMatcher.OrbitCenterPosition, 
          GameMatcher.OrbitRadius, 
          GameMatcher.WorldPosition, 
          GameMatcher.Speed, 
          GameMatcher.MovementAvailable, 
          GameMatcher.Moving));
    }

    public void Execute()
    {
      foreach (GameEntity mover in _movers)
      {
        float phase = mover.OrbitPhase + _time.DeltaTime * mover.Speed;
        mover.ReplaceOrbitPhase(phase);

        Vector3 newRelativePosition = new Vector3(
          Mathf.Cos(phase) * mover.OrbitRadius,
          Mathf.Sin(phase) * mover.OrbitRadius,
          0);

        Vector3 newPosition = newRelativePosition + mover.OrbitCenterPosition;
        
        mover.ReplaceWorldPosition(newPosition);
      }
    }
  }
}