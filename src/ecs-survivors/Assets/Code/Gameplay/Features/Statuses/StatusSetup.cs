﻿using System;

namespace Code.Gameplay.Features.Statuses
{
  [Serializable]
  public class StatusSetup
  {
    public StatusTypeId StatusTypeId;
    public float Value;
    public float Duration;
    public float Period;
  }
}