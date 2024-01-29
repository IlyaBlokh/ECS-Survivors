using Entitas;
using UnityEngine;

namespace Code.Gameplay.Input
{
  [Game] public class Input : IComponent { }
  [Game] public class AxisInput : IComponent { public Vector2 Value; }
}