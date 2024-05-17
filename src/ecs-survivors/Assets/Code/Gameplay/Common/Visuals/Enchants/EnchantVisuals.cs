﻿using UnityEngine;

namespace Code.Gameplay.Common.Visuals.Enchants
{
  public class EnchantVisuals : MonoBehaviour, IEnchantVisuals
  {
    private static readonly int ColorProperty = Shader.PropertyToID("_Color");
    private static readonly int ColorIntensityProperty = Shader.PropertyToID("_Intensity");
    private static readonly int OutlineSizeProperty = Shader.PropertyToID("_OutlineSize");
    private static readonly int OutlineColorProperty = Shader.PropertyToID("_OutlineColor");
    private static readonly int OutlineSmoothnessProperty = Shader.PropertyToID("_OutlineSmoothness");
   
    public Renderer Renderer;
    
    [Header("Freeze")]
    public Color FreezeColor = new Color32(56, 163, 190, 255);
    public float FreezeOutlineSize = 3;
    public float FreezeOutlineSmoothness = 8;
    
    [Header("Poison")]
    public Color PoisonColor = new Color32(56, 163, 190, 255);
    public float PoisonColorIntensity = 0.6f;
    
    public void ApplyFreeze()
    {
      Renderer.material.SetColor(OutlineColorProperty, FreezeColor);
      Renderer.material.SetFloat(OutlineSizeProperty, FreezeOutlineSize);
      Renderer.material.SetFloat(OutlineSmoothnessProperty, FreezeOutlineSmoothness);
    }
    
    public void UnapplyFreeze()
    {
      Renderer.material.SetColor(OutlineColorProperty, Color.white);
      Renderer.material.SetFloat(OutlineSizeProperty, 0f);
      Renderer.material.SetFloat(OutlineSmoothnessProperty, 0f);
    }

    public void ApplyPoison()
    {
      Renderer.material.SetColor(ColorProperty, PoisonColor);
      Renderer.material.SetFloat(ColorIntensityProperty, PoisonColorIntensity);
    }
    
    public void UnapplyPoison()
    {
      Renderer.material.SetColor(ColorProperty, Color.white);
      Renderer.material.SetFloat(ColorIntensityProperty, 0f);
    }
  }
}