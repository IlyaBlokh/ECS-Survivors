using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using Zenject;

namespace Code.Meta.UI.GoldHolder.Behaviours
{
  public class GoldHolder : MonoBehaviour
  {
    public TextMeshProUGUI Amount;
    public TextMeshProUGUI Boost;
    
    private IStorageUIService _storage;

    [Inject]
    private void Construct(IStorageUIService storageUIService) => 
      _storage = storageUIService;

    private void Start()
    {
      _storage.GoldChanged += UpdateGold;
      _storage.GoldBoostChanged += UpdateBoost;
      
      UpdateGold();
    }

    private void OnDestroy()
    {
      _storage.GoldChanged -= UpdateGold;
    }

    private void UpdateGold() => 
      Amount.text = _storage.CurrentGold.ToString("0");

    private void UpdateBoost()
    {
      float boost = _storage.GoldGainBoost;

      switch (boost)
      {
        case > 0:
          Boost.gameObject.SetActive(true);
          Boost.text = boost.ToString("+0%");
          break;
        default:
          Boost.gameObject.SetActive(false);
          break;
      }
    }
  }
}