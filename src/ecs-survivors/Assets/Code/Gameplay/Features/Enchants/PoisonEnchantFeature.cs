using Code.Infrastructure.Systems;

namespace Code.Gameplay.Features.Enchants.Systems
{
  public class PoisonEnchantFeature : Feature
  {
    public PoisonEnchantFeature(ISystemFactory systems)
    {
      Add(systems.Create<PoisonEnchantSystem>());
      Add(systems.Create<ApplyPoisonEnchantVisualsSystem>());
    }
  }
}