using Code.Gameplay.Windows;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Installers
{
  public class UIInitializer : MonoBehaviour, IInitializable
  {
    private IWindowFactory _windowFactory;
    
    public RectTransform UIRoot;

    [Inject]
    private void Construct(IWindowFactory windowFactory) => 
      _windowFactory = windowFactory;
    
    public void Initialize() => 
      _windowFactory.SetUIRoot(UIRoot);
  }
}