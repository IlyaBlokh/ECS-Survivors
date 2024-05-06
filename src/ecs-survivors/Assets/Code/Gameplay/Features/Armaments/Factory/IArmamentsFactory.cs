using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
  public interface IArmamentsFactory
  {
    GameEntity CreateVegetableBolt(int level, Vector3 at);
    GameEntity CreateShovelBolt(int level, Vector3 at);
    GameEntity CreateBeerBolt(int level, Vector3 at);
    GameEntity CreateMainFireball(int level, Vector3 at);
    GameEntity CreateChildFireball(int level, Vector3 at);
  }
}