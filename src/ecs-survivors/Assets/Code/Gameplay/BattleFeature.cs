using Code.Common.Destruct;
using Code.Gameplay.Features.DamageApplication;
using Code.Gameplay.Features.Enemies;
using Code.Gameplay.Features.Hero;
using Code.Gameplay.Features.Movement;
using Code.Gameplay.Features.TargetCollection;
using Code.Gameplay.Input;
using Code.Infrastructure.Systems;

namespace Code.Gameplay
{
  public class BattleFeature : Feature
  {
    public BattleFeature(ISystemFactory systems)
    {
      Add(systems.Create<InputFeature>());
      
      Add(systems.Create<HeroFeature>());
      Add(systems.Create<EnemyFeature>());
      Add(systems.Create<DeathFeature>());
      
      Add(systems.Create<MovementFeature>());
      Add(systems.Create<CollectTargetsFeature>());
      Add(systems.Create<DamageApplicationFeature>());
      
      Add(systems.Create<ProcessDestructedFeature>());
    }
  }
}