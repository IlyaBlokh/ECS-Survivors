using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Code.Gameplay.Features.Armaments
{
  [Game] public class Armament : IComponent { }
  [Game] public class BeerBoltArmament : IComponent { }
  [Game] public class TargetLimit : IComponent { public int Value; }
  [Game] public class Processed : IComponent { }
  [Game] [FlagPrefix("")] public class RequiresNextNearestEnemy : IComponent { }
}