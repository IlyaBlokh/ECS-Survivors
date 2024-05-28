using System.Collections.Generic;
using Code.Gameplay.Features.Abilities;
using Code.Gameplay.Features.Abilities.Upgrade;
using Code.Gameplay.Features.Armaments.Factory;
using Entitas;

namespace Code.Gameplay.Features.Armaments.Systems
{
  public class SpawnNapalmOnBombReachedSystem : ReactiveSystem<GameEntity>
  {
    private readonly IArmamentFactory _armamentFactory;
    private readonly IAbilityUpgradeService _abilityUpgradeService;

    public SpawnNapalmOnBombReachedSystem(GameContext game, IArmamentFactory armamentFactory, IAbilityUpgradeService abilityUpgradeService) : base(game)
    {
      _abilityUpgradeService = abilityUpgradeService;
      _armamentFactory = armamentFactory;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context) =>
      context.CreateCollector(GameMatcher
        .AllOf(
          GameMatcher.Armament, 
          GameMatcher.WorldPosition,
          GameMatcher.TargetDestination,
          GameMatcher.Reached).Added());

    protected override bool Filter(GameEntity entity) => entity.isArmament && entity.hasTargetDestination && entity.isReached;

    protected override void Execute(List<GameEntity> armaments)
    {
        foreach (GameEntity armament in armaments)
        {
          int bombLevel = _abilityUpgradeService.GetAbilityLevel(AbilityId.NapalmBomb);
          _armamentFactory.CreateNapalmAura(bombLevel, armament.WorldPosition);
          armament.isDestructed = true;
        }
    }
  }
}