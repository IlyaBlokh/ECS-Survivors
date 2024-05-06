using Code.Gameplay.Features.Abilities.Features;
using Code.Gameplay.Features.Abilities.Systems;
using Code.Gameplay.Features.Cooldowns.Systems;
using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Abilities
{
  public class AbilityFeature : Feature
  {
    public AbilityFeature(ISystemFactory systems)
    {
      Add(systems.Create<CooldownSystem>());
      Add(systems.Create<VegetableBoltAbilitySystem>());
      Add(systems.Create<ShovelRadialStrikeAbilitySystem>());
      Add(systems.Create<BouncingBeerAbilityFeature>());
      Add(systems.Create<ScatteringFireballFeature>());
    }
  }
}