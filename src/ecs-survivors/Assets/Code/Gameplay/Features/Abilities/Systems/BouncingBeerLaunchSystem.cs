using System.Collections.Generic;
using System.Linq;
using Code.Common.Extensions;
using Code.Gameplay.Features.Armaments.Factory;
using Code.Gameplay.Features.Cooldowns;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Abilities.Systems
{
  public class BouncingBeerLaunchSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _abilities;
    private readonly IStaticDataService _staticDataService;
    private readonly IArmamentsFactory _armamentsFactory;
    private readonly List<GameEntity> _buffer = new(1);
    private readonly IGroup<GameEntity> _heroes;
    
    public BouncingBeerLaunchSystem(GameContext game, IStaticDataService staticDataService, IArmamentsFactory armamentsFactory)
    {
      _armamentsFactory = armamentsFactory;
      _staticDataService = staticDataService;
      
      _abilities = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.BouncingBeerAbility, 
          GameMatcher.CooldownUp));

      _heroes = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Hero,
          GameMatcher.WorldPosition));
    }

    public void Execute()
    {
      foreach (GameEntity ability in _abilities.GetEntities(_buffer))
        foreach (GameEntity hero in _heroes)
        {
          _armamentsFactory
            .CreateBeerBolt(1, hero.WorldPosition)
            .With(x => x.RequiresNextNearestEnemy = true)
            .With(x => x.isMoving = true);
          
          ability
            .PutOnCooldown(_staticDataService.GetAbilityLevel(AbilityId.BouncingBeer, 1).Cooldown);
        }
    }
  }
}