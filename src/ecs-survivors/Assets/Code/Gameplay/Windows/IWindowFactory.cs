using UnityEngine;

namespace Code.Gameplay.Windows
{
  public interface IWindowFactory
  {
    public void SetUIRoot(RectTransform uiRoot);
    public BaseWindow CreateWindow(WindowId windowId);
  }
}