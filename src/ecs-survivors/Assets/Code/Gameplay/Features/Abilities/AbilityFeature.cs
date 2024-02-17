using Code.Gameplay.Features.Abilities.System;
using Code.Gameplay.Features.Abilities.Systems;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities
{
  public sealed class AbilityFeature : Feature
  {
    public AbilityFeature(ISystemFactory systems)
    {
      Add(systems.Create<CooldownSystem>());
      Add(systems.Create<DestroyAbilityEntitiesOnUpgradeSystem>());

      Add(systems.Create<VegetableBoltAbilitySystem>());
      Add(systems.Create<OrbitingMushroomAbilitySystem>());
      Add(systems.Create<GarlicAuraAbilitySystem>());
    }
  }
}