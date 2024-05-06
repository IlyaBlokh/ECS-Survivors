namespace Code.Gameplay.Features.Abilities.Factory
{
  public interface IAbilityFactory
  {
    GameEntity CreateVegetableBoltAbility(int level);
    GameEntity CreateShovelRadialStrikeAbility(int level);
    GameEntity CreateBouncingBeerAbility(int level);
  }
}