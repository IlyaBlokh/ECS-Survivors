using System.Collections.Generic;
using Code.Gameplay.Features.Statuses;
using Code.Gameplay.StaticData;
using Entitas;

namespace Code.Gameplay.Features.Enchants.Systems
{
  public class HexEnchantSystem : IExecuteSystem
  {
    private readonly IGroup<GameEntity> _enchants;
    private readonly IGroup<GameEntity> _armaments;
    private readonly List<GameEntity> _buffer = new(32);
    
    private readonly IStaticDataService _staticDataService;

    public HexEnchantSystem(GameContext game, IStaticDataService staticDataService)
    {
      _staticDataService = staticDataService;
      _enchants = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.EnchantTypeId, 
          GameMatcher.HexEnchant,
          GameMatcher.ProducerId));
      
      _armaments = game.GetGroup(GameMatcher
        .AllOf(
          GameMatcher.Armament, 
          GameMatcher.ProducerId)
        .NoneOf(GameMatcher.HexEnchant));
    }

    public void Execute()
    {
      foreach (GameEntity enchant in _enchants)
        foreach (GameEntity armament in _armaments.GetEntities(_buffer))
        {
          if (enchant.ProducerId == armament.ProducerId)
          {
            GetOrAddStatusSetups(armament)
              .AddRange(_staticDataService.GetEnchantConfig(EnchantTypeId.HexArmaments).StatusSetups);
            armament.isHexEnchant = true;
          }
        }
    }

    private static List<StatusSetup> GetOrAddStatusSetups(GameEntity armament)
    {
      if (!armament.hasStatusSetups)
        armament.AddStatusSetups(new List<StatusSetup>());
      
      return armament.StatusSetups;
    }
  }
}