namespace Code.Gameplay.Features.Abilities.Factory
{
  public interface IAbilityFactory
  {
    GameEntity CreateVegetableBoltAbility(int level);
    GameEntity CreateOrbitingMushroomAbility(int level);
    GameEntity CreateGarlicAuraAbility();
    GameEntity CreateSpeedUpAuraAbility(int producerId);
    GameEntity CreateHealAuraAbility(int producerId);
    GameEntity CreateNapalmBombAbility(int level);
    GameEntity CreateShovelRadialStrikeAbility(int level);
    GameEntity CreateBouncingBeerAbility(int level);
    GameEntity CreateScatteringFireballAbility(int level);
  }
}