using System;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class ProjectileSetup
  {
    public float Speed;
    public float AngleSpeed;
    public float ContactRadius;
    public float Lifetime;
    public int Pierce = 1;
    [Header("Bouncing Beer Ability")]
    public int Bounce;
  }
}