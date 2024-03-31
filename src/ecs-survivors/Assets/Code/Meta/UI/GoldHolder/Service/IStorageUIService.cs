using System;

namespace Code.Meta.UI.GoldHolder.Service
{
  public interface IStorageUIService
  {
    event Action GoldChanged;
    float CurrentGold { get; }
    float GoldGainBoost { get; }
    void UpdateCurrentGold(float gold);
    void Cleanup();
    event Action GoldBoostChanged;
    void UpdateGoldGainBoost(float boost);
  }
}