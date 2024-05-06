using System.Collections.Generic;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Hero.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Hero
{
  [Game] public class Hero : IComponent { }
  [Game] public class HeroAnimatorComponent : IComponent { public HeroAnimator Value; }
  [Game] public class KillScore : IComponent { public int Value; }
  [Game] public class Abilities : IComponent { public List<AbilityId> Value; }
}