using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Abilities.Configs;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;

namespace Code.Gameplay.Features.Abilities.Factory
{
  public class AbilityFactory : IAbilityFactory
  {
    private readonly IIdentifierService _identifiers;
    private readonly IStaticDataService _staticDataService;

    public AbilityFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
    {
      _identifiers = identifiers;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateVegetableBoltAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.VegetableBolt, level);
      
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.VegetableBolt)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isVegetableBoltAbility = true)
        .PutOnCooldown();
    }    
    
    public GameEntity CreateSpeedUpAuraAbility(int producerId)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.SpeedUpAura)
        .AddProducerId(producerId)
        .With(x => x.isSpeedUpAuraAbility = true);
    }    
    
    public GameEntity CreateHealAuraAbility(int producerId)
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.HealAura)
        .AddProducerId(producerId)
        .With(x => x.isHealAuraAbility = true);
    }

    public GameEntity CreateNapalmBombAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.NapalmBomb, level);
      
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.NapalmBomb)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isNapalmBombAbility = true)
        .PutOnCooldown();
    }

    public GameEntity CreateOrbitingMushroomAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.OrbitingMushroom, level);
      
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.OrbitingMushroom)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isOrbitingMushroomAbility = true)
        .With(x => x.isRecreatedOnUpgrade = true)
        .PutOnCooldown();
    }

    public GameEntity CreateGarlicAuraAbility()
    {
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.GarlicAura)
        .With(x => x.isRecreatedOnUpgrade = true)
        .With(x => x.isGarlicAuraAbility = true);
    }
  }
}