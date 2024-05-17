using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
  public interface IArmamentFactory
  {
    GameEntity CreateVegetableBolt(int level, Vector3 at);
    GameEntity CreateMushroom(int level, Vector3 at, float phase);
  }
}