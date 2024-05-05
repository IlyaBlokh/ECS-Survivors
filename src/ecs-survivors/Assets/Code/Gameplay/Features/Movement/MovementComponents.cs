using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

namespace Code.Gameplay.Features.Movement
{
  [Game] public class Speed : IComponent { public float Value; }
  [Game] public class AngleSpeed : IComponent { public float Value; }
  [Game] public class Direction : IComponent { public Vector2 Value; }
  [Game] public class Moving : IComponent { }
  [Game] public class TurnedAlongDirection : IComponent { }
  [Game] public class RotationAlignedAlongDirection : IComponent { }
  [Game] [FlagPrefix("")] public class RotatesAroundCenter : IComponent { }
  [Game] public class MovementAvailable : IComponent { }
}