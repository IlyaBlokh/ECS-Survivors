using System;

namespace Code.Meta.UI.GoldHolder.Service
{
  public class StorageUIService : IStorageUIService
  {
    private float _currentGold;
    private float _goldGainBoost;

    public event Action GoldChanged;
    public event Action GoldBoostChanged;
    
    public float CurrentGold => _currentGold;
    public float GoldGainBoost => _goldGainBoost;

    public void UpdateGoldGainBoost(float boost)
    {
      _goldGainBoost = boost;
      GoldBoostChanged?.Invoke();
    }

    public void UpdateCurrentGold(float gold)
    {
      if (Math.Abs(gold - _currentGold) > float.Epsilon)
      {
        _currentGold = gold;
        GoldChanged?.Invoke();
      }
    }

    public void Cleanup()
    {
      _currentGold = 0f;
      _goldGainBoost = 0f;

      GoldChanged = null;
      GoldBoostChanged = null;
    }
  }
}