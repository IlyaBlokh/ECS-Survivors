using Code.Gameplay.Common.Visuals.Enchants;
using Code.Gameplay.Features.Enchants.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Enchants
{
  [Game] public class EnchantTypeIdComponent : IComponent { public EnchantTypeId Value; }
  [Game] public class EnchantVisualsComponent : IComponent { public IEnchantVisuals Value; }
  [Game] public class PoisonEnchant : IComponent { }
  [Game] public class ExplosiveEnchant : IComponent { }
  [Game] public class EnchantsHolderComponent : IComponent { public EnchantHolder Value; }
}