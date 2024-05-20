using Code.Gameplay.Features.Abilities;
using UnityEngine;

namespace Code.Gameplay.Features.Armaments.Factory
{
  public interface IArmamentFactory
  {
    GameEntity CreateVegetableBolt(int level, Vector3 at);
    GameEntity CreateMushroom(int level, Vector3 at, float phase);
    GameEntity CreateGarlicEffectAura(AbilityId parentAbilityId, int producerId, int level);
    GameEntity CreateExplosion(int producerId, Vector3 at);
    GameEntity CreateSpeedUpEffectAura(AbilityId parentAbilityId, int producerId, int level);
  }
}