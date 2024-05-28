using UnityEngine;

namespace Code.Gameplay.Common.Random
{
  public class UnityRandomService : IRandomService
  {
    public float Range(float inclusiveMin, float inclusiveMax) => 
      UnityEngine.Random.Range(inclusiveMin, inclusiveMax);

    public int Range(int inclusiveMin, int exclusiveMax) => 
      UnityEngine.Random.Range(inclusiveMin, exclusiveMax);

    public Vector2 RandomInRadius(float radius) => 
      UnityEngine.Random.insideUnitCircle * radius;
  }
}