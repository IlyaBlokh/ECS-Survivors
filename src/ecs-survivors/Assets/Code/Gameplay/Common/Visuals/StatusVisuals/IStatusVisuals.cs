using UnityEngine;

namespace Code.Gameplay.Common.Visuals.StatusVisuals
{
  public interface IStatusVisuals
  {
    void ApplyFreeze();
    void UnapplyFreeze();
    void ApplyPoison();
    void UnapplyPoison();
    void ApplyMetamorph(Sprite viewImage);
    void UnapplyMetamorph();
  }
}