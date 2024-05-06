using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.Geometry
{
  public class GeometryService : IGeometryService
  {
    public IEnumerable<Vector2> GetRadialDirections(int amount)
    {
      float angleBetween = 2 * Mathf.PI / amount;
      for (int i = 0; i < amount; i++)
      {
        float x = Mathf.Cos(i * angleBetween);
        float y = Mathf.Sin(i * angleBetween);
        yield return new Vector2(x, y).normalized;
      }
    }
  }
}