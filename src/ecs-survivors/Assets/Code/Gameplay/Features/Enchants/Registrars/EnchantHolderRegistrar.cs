using Code.Gameplay.Features.Enchants.Behaviours;
using Code.Infrastructure.View.Registrars;

namespace Code.Gameplay.Features.Enchants.Registrars
{
  public class EnchantHolderRegistrar : EntityComponentRegistrar
  {
    public EnchantHolder EnchantHolder;

    public override void RegisterComponents() =>
      Entity.AddEnchantsHolder(EnchantHolder);

    public override void UnregisterComponents()
    {
      if (Entity.hasEnchantsHolder)
        Entity.RemoveEnchantsHolder();
    }
  }
}