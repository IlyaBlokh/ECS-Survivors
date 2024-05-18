using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Common.Visuals.Enchants
{
  public class EnchantVisualsRegistrar : EntityComponentRegistrar
  {
    public EnchantVisuals EnchantVisuals;

    public override void RegisterComponents()
    {
      Entity.AddEnchantVisuals(EnchantVisuals);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasEnchantVisuals)
        Entity.RemoveEnchantVisuals();
    }
  }
}