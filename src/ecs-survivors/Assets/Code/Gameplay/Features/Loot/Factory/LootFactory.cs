using Code.Common.Entity;
using Code.Common.Extensions;
using Code.Gameplay.Features.Loot.Configs;
using Code.Gameplay.StaticData;
using Code.Infrastructure.Identifiers;
using UnityEngine;

namespace Code.Gameplay.Features.Loot.Factory
{
  public class LootFactory : ILootFactory
  {
    private readonly IIdentifierService _identifiers;
    private readonly IStaticDataService _staticDataService;

    public LootFactory(IIdentifierService identifiers, IStaticDataService staticDataService)
    {
      _identifiers = identifiers;
      _staticDataService = staticDataService;
    }

    public GameEntity CreateLootItem(LootTypeId typeId, Vector3 at)
    {
      LootConfig config = _staticDataService.GetLootConfig(typeId);

      return CreateEntity.Empty()
          .AddId(_identifiers.Next())
          .AddWorldPosition(at)
          .AddLootTypeId(typeId)
          .AddViewPrefab(config.ViewPrefab)
          .With(x => x.AddExperience(config.Experience), when: config.Experience > 0)
          .With(x => x.AddEffectSetups(config.EffectSetups), when: !config.EffectSetups.IsNullOrEmpty())
          .With(x => x.AddStatusSetups(config.StatusSetups), when: !config.StatusSetups.IsNullOrEmpty())
          .With(x => x.isPullable = true)
        ;
    }
  }
}