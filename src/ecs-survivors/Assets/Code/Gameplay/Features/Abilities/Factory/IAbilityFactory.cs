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
  }
}