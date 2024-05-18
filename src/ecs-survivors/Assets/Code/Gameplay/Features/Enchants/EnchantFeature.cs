using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enchants.Systems
{
  public class EnchantFeature : Feature
  {
    public EnchantFeature(ISystemFactory systems)
    {
      Add(systems.Create<PoisonEnchantSystem>());
      Add(systems.Create<ApplyPoisonEnchantVisualsSystem>());
      Add(systems.Create<ExplosiveEnchantSystem>());
    }
  }
}