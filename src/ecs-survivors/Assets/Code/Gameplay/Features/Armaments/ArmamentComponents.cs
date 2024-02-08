using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Entitas;

namespace Code.Gameplay.Features.Armaments
{
  [Game] public class Armament : IComponent { }
  [Game] public class TargetLimit : IComponent { public int Value; }
  [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
  [Game] public class Processed : IComponent { }
}