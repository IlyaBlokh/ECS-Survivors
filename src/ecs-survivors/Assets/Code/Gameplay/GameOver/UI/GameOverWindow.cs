using Code.Gameplay.Windows;
using Code.Infrastructure.States.GameStates;
using Code.Infrastructure.States.StateMachine;
using UnityEngine.UI;
using Zenject;

namespace Code.Gameplay.GameOver.UI
{
  public class GameOverWindow : BaseWindow
  {
    public Button ReturnHomeButton;

    private IGameStateMachine _gameStateMachine;
    private IWindowService _windowService;

    [Inject]
    private void Construct(IGameStateMachine stateMachine, IWindowService windowService)
    {
      Id = WindowId.GameOverWindow;

      _gameStateMachine = stateMachine;
      _windowService = windowService;
    }

    protected override void Initialize()
    {
      ReturnHomeButton.onClick.AddListener(ReturnHome);
    }

    private void ReturnHome()
    {
      _windowService.Close(Id);
      
      _gameStateMachine.Enter<LoadingHomeScreenState>();
    }
  }
}