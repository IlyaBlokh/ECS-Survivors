using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Armaments
{
  [Game] public class Armament : IComponent { }
  [Game] public class TargetLimit : IComponent { public int Value; }
  [Game] public class EffectSetups : IComponent { public List<EffectSetup> Value; }
  [Game] public class StatusSetups : IComponent { public List<StatusSetup> Value; }
  [Game] public class Processed : IComponent { }
  [Game] public class FollowingProducer : IComponent { }
  [Game] public class BeerBoltArmament : IComponent { }
  [Game] public class ScatteringFireballArmament : IComponent { }
  [Game] [FlagPrefix("")] public class RequiresNextNearestEnemy : IComponent { }
}