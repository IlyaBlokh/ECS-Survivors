using Code.Meta.UI.GoldHolder.Service;
using Entitas;

namespace Code.Meta.UI.GoldHolder.Systems
{
  public class RefreshGoldSystem : IExecuteSystem
  {
    private readonly IGroup<MetaEntity> _storages;
    private readonly IStorageUIService _storage;

    public RefreshGoldSystem(MetaContext meta, IStorageUIService storage)
    {
      _storage = storage;
      _storages = meta.GetGroup(MetaMatcher
        .AllOf(
          MetaMatcher.Storage, 
          MetaMatcher.Gold));
    }

    public void Execute()
    {
      foreach (MetaEntity storage in _storages) 
        _storage.UpdateCurrentGold(storage.Gold);
    }
  }
}