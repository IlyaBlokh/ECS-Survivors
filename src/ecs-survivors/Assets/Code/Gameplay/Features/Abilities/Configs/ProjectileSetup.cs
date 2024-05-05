using System;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class ProjectileSetup
  {
    public float Speed;
    public float AngleSpeed;
    public int Pierce = 1;
    public float ContactRadius;
    public float Lifetime;
  }
}