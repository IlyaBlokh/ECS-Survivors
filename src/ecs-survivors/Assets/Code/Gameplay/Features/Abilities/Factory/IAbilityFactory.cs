namespace Code.Gameplay.Features.Abilities.Factory
{
  public interface IAbilityFactory
  {
    GameEntity CreateVegetableBoltAbility(int level);
    GameEntity CreateOrbitingMushroomAbility(int level);
    GameEntity CreateGarlicAuraAbility();
  }
}