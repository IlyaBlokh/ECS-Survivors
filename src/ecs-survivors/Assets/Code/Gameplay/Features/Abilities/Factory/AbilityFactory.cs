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
    
    public GameEntity CreateShovelRadialStrikeAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ShovelRadialStrike, level);
      
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.ShovelRadialStrike)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isShovelRadialStrikeAbility = true)
        .PutOnCooldown();
    }    
    
    public GameEntity CreateBouncingBeerAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.BouncingBeer, level);
      
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.BouncingBeer)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isBouncingBeerAbility = true)
        .PutOnCooldown();
    }    
    
    public GameEntity CreateScatteringFireballAbility(int level)
    {
      AbilityLevel abilityLevel = _staticDataService.GetAbilityLevel(AbilityId.ScatteringFireball, level);
      
      return CreateEntity.Empty()
        .AddId(_identifiers.Next())
        .AddAbilityId(AbilityId.ScatteringFireball)
        .AddCooldown(abilityLevel.Cooldown)
        .With(x => x.isScatteringFireballAbility = true)
        .PutOnCooldown();
    }
  }
}