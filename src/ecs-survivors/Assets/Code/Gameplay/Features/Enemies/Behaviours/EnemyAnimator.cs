using Code.Gameplay.Common.Visuals;
using DG.Tweening;
using UnityEngine;

namespace Code.Gameplay.Features.Enemies.Behaviours
{
  public class EnemyAnimator : MonoBehaviour, IDamageTakenAnimator
  {
    private static readonly int OverlayIntensityProperty = Shader.PropertyToID("_OverlayIntensity");
    
    private readonly int _diedHash = Animator.StringToHash("died");
    
    public Animator Animator;
    public SpriteRenderer SpriteRenderer;
    private Material Material => SpriteRenderer.material;

    public void PlayDied() => Animator.SetTrigger(_diedHash);

    public void PlayDamageTaken()
    {
      if (DOTween.IsTweening(Material))
        return;
      
      Material.DOFloat(0.4f, OverlayIntensityProperty, 0.15f)
        .OnComplete(() =>
        {
          if (SpriteRenderer)
            Material.DOFloat(0, OverlayIntensityProperty, 0.15f);
        });
    }
    
    public void ResetAll()
    {
      Animator.ResetTrigger(_diedHash);
    }
  }
}