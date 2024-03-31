using System;
using System.Collections.Generic;
using Code.Gameplay.Windows;
using Code.Meta.UI.GoldHolder.Service;
using Code.Meta.UI.Shop.Items;
using Code.Meta.UI.Shop.Service;
using Code.Meta.UI.Shop.UIFactory;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.Shop
{
  public class ShopWindow : BaseWindow
  {
    public Transform ItemsLayout;
    public Button CloseButton;
    public GameObject NoItemsAvailable;
    
    private IWindowService _windowService;
    private IShopUIFactory _shopUIFactory;
    private IShopUIService _shop;
    private IStorageUIService _storage;

    private readonly List<ShopItem> _items = new();

    [Inject]
    private void Construct(
      IWindowService windowService, 
      IShopUIFactory shopUIFactory, 
      IShopUIService shop,
      IStorageUIService storage) 
    {
      Id = WindowId.ShopWindow;

      _shopUIFactory = shopUIFactory;
      _windowService = windowService;
      _shop = shop;
      _storage = storage;
    }

    protected override void Initialize() => 
      CloseButton.onClick.AddListener(Close);

    protected override void SubscribeUpdates()
    {
      _shop.ShopChanged += Refresh;
      _storage.GoldBoostChanged += UpdateBoostersState;
      
      Refresh();
    }

    protected override void UnsubscribeUpdates()
    {
      _shop.ShopChanged -= Refresh;
    }


    private void Refresh()
    {
      ClearItems();

      List<ShopItemConfig> availableConfigs = _shop.GetAvailableShopItems;
      
      NoItemsAvailable.SetActive(availableConfigs.Count == 0);

      FillItems(availableConfigs);

      UpdateBoostersState();
    }

    protected override void Cleanup()
    {
      base.Cleanup();
      
      CloseButton.onClick.RemoveListener(Close);
    }

    private void FillItems(List<ShopItemConfig> availableItems)
    {
      foreach (ShopItemConfig shopItemConfig in availableItems) 
        _items.Add(_shopUIFactory.CreateShopItem(shopItemConfig, ItemsLayout));
    }

    private void UpdateBoostersState()
    {
      bool itemsCanBeBought = Math.Abs(_storage.GoldGainBoost - 0) <= float.Epsilon;

      foreach (ShopItem shopItem in _items) 
        shopItem.UpdateAvailability(itemsCanBeBought);
    }

    private void ClearItems()
    {
      _items.ForEach(x => Destroy(x.gameObject));
      _items.Clear();
    }

    private void Close()
    {
      _windowService.Close(Id);
    }
  }
}