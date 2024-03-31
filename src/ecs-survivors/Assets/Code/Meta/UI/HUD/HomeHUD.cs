using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.Meta.UI.HUD
{
  public class HomeHUD : MonoBehaviour
  {
    private const string BattleSceneName = "Meadow";
    
    private IGameStateMachine _stateMachine;
    private IWindowService _windowService;

    public Button StartBattleButton;
    public Button ShopButton;

    [Inject]
    private void Construct(IGameStateMachine gameStateMachine, IWindowService windowService)
    {
      _stateMachine = gameStateMachine;
      _windowService = windowService;
    }

    private void Awake()
    {
      StartBattleButton.onClick.AddListener(EnterBattleLoadingState);
      ShopButton.onClick.AddListener(OpenShop);
    }

    private void EnterBattleLoadingState() => 
      _stateMachine.Enter<LoadingBattleState, string>(BattleSceneName);
    
    private void OpenShop()
    {
      _windowService.Open(WindowId.ShopWindow);
    }
  }
}