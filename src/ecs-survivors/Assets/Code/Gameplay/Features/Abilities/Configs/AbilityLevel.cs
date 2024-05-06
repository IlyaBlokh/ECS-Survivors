using System;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class AbilityLevel
  {
    public float Cooldown;
    public EntityBehaviour ViewPrefab;
    public ProjectileSetup ProjectileSetup;
    
    [Header("Shovel Strike Ability")]
    public int ProjectileAmount;
    
    [Header("Scattering Fireball Ability")]
    public EntityBehaviour ChildViewPrefab;
    public ProjectileSetup ChildProjectile;
  }
}