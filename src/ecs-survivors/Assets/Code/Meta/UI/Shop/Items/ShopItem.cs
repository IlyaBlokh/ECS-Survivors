using System;
using Code.Common.Entity;
using Code.Meta.UI.GoldHolder.Service;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop.Items
{
  public class ShopItem : MonoBehaviour
  {
    public ShopItemId Id;
    
    public Image Icon;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI Duration;
    public TextMeshProUGUI Boost;
    public Button BuyButton;
    public CanvasGroup CanvasGroup;

    public Color EnoughColor;
    public Color NotEnoughColor;
    
    private bool _isAvailable;
    private int _price;
    private float _currentGold;

    private IStorageUIService _storage;

    private bool EnoughGold => _currentGold >= _price;

    [Inject]
    private void Construct(IStorageUIService storage) => 
      _storage = storage;

    public void Setup(ShopItemConfig config)
    {
      Id = config.ShopItemId;
      
      Icon.sprite = config.Icon;
      Price.text = config.Price.ToString();
      Duration.text = TimeSpan.FromSeconds(config.Duration).ToString("m'm 's's'");
      Boost.text = config.Boost.ToString("+0%");

      _price = config.Price;
      
      BuyButton.onClick.AddListener(BuyItem);
    }

    private void Start()
    {
      _storage.GoldChanged += UpdatePriceThreshold;
      
      UpdatePriceThreshold();
    }

    private void OnDestroy()
    {
      _storage.GoldChanged -= UpdatePriceThreshold;
      
      BuyButton.onClick.RemoveListener(BuyItem);
    }

    public void UpdateAvailability(bool value)
    {
      _isAvailable = value;
      CanvasGroup.alpha = _isAvailable ? 1f : 0.7f;

      RefreshBuyButton();
    }

    private void UpdatePriceThreshold()
    {
      _currentGold = _storage.CurrentGold;
      Price.color = EnoughGold ? EnoughColor : NotEnoughColor;
      
      RefreshBuyButton();
    }

    private void RefreshBuyButton() => 
      BuyButton.interactable = EnoughGold & _isAvailable;

    private void BuyItem()
    {
      CreateMetaEntity.Empty()
        .AddShopItemId(Id)
        .isBuyRequest = true;
    }
  }
}