using Entitas;

namespace Code.Meta.Features.Simulation.Systems
{
  public class AfkGoldGainSystem : IExecuteSystem
  {
    private readonly IGroup<MetaEntity> _tick;
    private readonly IGroup<MetaEntity> _storage;

    public AfkGoldGainSystem(MetaContext meta)
    {
      _tick = meta.GetGroup(MetaMatcher.Tick);
      _storage = meta.GetGroup(MetaMatcher
        .AllOf(
          MetaMatcher.Storage,
          MetaMatcher.Gold,
          MetaMatcher.GoldPerSecond));
    }

    public void Execute()
    {
      foreach (MetaEntity tick in _tick)
      foreach (MetaEntity storage in _storage)
      {
        storage.ReplaceGold(storage.Gold + tick.Tick * storage.GoldPerSecond);
      }
    }
  }
}