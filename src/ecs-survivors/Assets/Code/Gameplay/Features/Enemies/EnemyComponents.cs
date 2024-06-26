﻿using System.Collections.Generic;
using Code.Gameplay.Features.Enemies.Behaviours;
using Entitas;

namespace Code.Gameplay.Features.Enemies
{
  [Game] public class Enemy : IComponent { }
  [Game] public class EnemyAnimatorComponent : IComponent { public EnemyAnimator Value; }
  [Game] public class SpawnTimer : IComponent { public float Value; }
  [Game] public class SpawnProgress : IComponent { }
  [Game] public class EnemyTypeIdComponent : IComponent { public EnemyTypeId Value; }
  [Game] public class EnemyTypes : IComponent { public List<EnemyTypeId> Value; }
  [Game] public class Goblin : IComponent { }
  [Game] public class Buffer : IComponent { }
  [Game] public class Healer : IComponent { }
  [Game] public class ScheduledToProcessByArmaments : IComponent { public List<int> Value; }
  [Game] public class ProcessedByArmaments: IComponent { public List<int> Value; }
}