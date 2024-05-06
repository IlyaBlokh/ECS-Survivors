using System.Collections.Generic;
using UnityEngine;

namespace Code.Gameplay.Common.Geometry
{
  public interface IGeometryService
  {
    IEnumerable<Vector2> GetRadialDirections(int amount);
  }
}