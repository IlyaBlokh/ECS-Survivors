using Entitas;

namespace Code.Gameplay.Features.Abilities
{
  [Game] public class AbilityIdComponent : IComponent { public AbilityId Value; }
  [Game] public class VegetableBoltAbility : IComponent { }
  [Game] public class ShovelRadialStrikeAbility : IComponent { }
  [Game] public class BouncingBeerAbility : IComponent { }
}