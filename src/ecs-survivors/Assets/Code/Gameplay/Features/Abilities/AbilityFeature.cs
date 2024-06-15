using Code.Gameplay.Features.Abilities.Features;
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
      Add(systems.Create<SpeedUpAuraAbilitySystem>());
      Add(systems.Create<HealAuraAbilitySystem>());
      Add(systems.Create<NapalmBombAbilitySystem>());
      Add(systems.Create<ShovelRadialStrikeAbilitySystem>());
      Add(systems.Create<BouncingBeerAbilityFeature>());
      Add(systems.Create<ScatteringFireballFeature>());
    }
  }
}