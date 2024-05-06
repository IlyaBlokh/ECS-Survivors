using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class LaunchScatteringFireballAbilitySystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _abilities;
    private readonly IStaticDataService _staticDataService;
    private readonly IArmamentsFactory _armamentsFactory;
    private readonly List<GameEntity> _buffer = new(1);
    private readonly IGroup<GameEntity> _heroes;
    private readonly IGroup<GameEntity> _enemies;

    public LaunchScatteringFireballAbilitySystem(GameContext game, IStaticDataService staticDataService, IArmamentsFactory armamentsFactory)
    {
      _armamentsFactory = armamentsFactory;
      _staticDataService = staticDataService;
      
      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.ScatteringFireballAbility, 
          GameMatcher.CooldownUp));

      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
      
      _enemies = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Enemy,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
        foreach (GameEntity hero in _heroes)
        {
          if (_enemies.count <= 0)
            continue;
          
          _armamentsFactory.CreateMainFireball(1, hero.WorldPosition)
            .ReplaceDirection((FirstAvailableTarget().WorldPosition - hero.WorldPosition).normalized)
            .With(x => x.isMoving = true);
          
          ability
            .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.ScatteringFireball, 1).Cooldown);
        }
    }

    private GameEntity FirstAvailableTarget() => 
      _enemies.AsEnumerable().First();
  }
}