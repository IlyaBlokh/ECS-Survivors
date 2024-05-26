using Code.Gameplay.Features.Enchants.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enchants.Registrars
{
  public class EnchantHolderRegistrar : EntityComponentRegistrar
  {
    public EnchantHolder EnchantHolder;
    public override void RegisterComponents()
    {
      Entity.AddEnchantHolder(EnchantHolder);
    }

    public override void UnregisterComponents()
    {
      if (Entity.hasEnchantHolder)
        Entity.RemoveEnchantHolder();
    }
  }
}