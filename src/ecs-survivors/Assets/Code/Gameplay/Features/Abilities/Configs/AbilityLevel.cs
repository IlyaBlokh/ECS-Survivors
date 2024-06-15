﻿using System;
using System.Collections.Generic;
using Code.Gameplay.Features.Effects;
using Code.Gameplay.Features.Statuses;
using Code.Infrastructure.View;
using UnityEngine;

namespace Code.Gameplay.Features.Abilities.Configs
{
  [Serializable]
  public class AbilityLevel
  {
    public Sprite Icon;
    public string Description;
    
    public float Cooldown;

    public EntityBehaviour ViewPrefab;

    public List<EffectSetup> EffectSetups;
    public List<StatusSetup> StatusSetups;
    
    public ProjectileSetup ProjectileSetup;
    public AuraSetup AuraSetup;
    
    [Header("Shovel Strike Ability")]
    public int ProjectileAmount;
    
    [Header("Scattering Fireball Ability")]
    public EntityBehaviour ChildViewPrefab;
    public ProjectileSetup ChildProjectile;
  }
}