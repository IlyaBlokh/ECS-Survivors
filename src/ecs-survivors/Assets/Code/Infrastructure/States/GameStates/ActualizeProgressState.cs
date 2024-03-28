using System;
using Code.Common.Entity;
using Code.Gameplay.Common.Time;
using Code.Infrastructure.States.StateInfrastructure;
using Code.Infrastructure.States.StateMachine;
using Code.Infrastructure.Systems;
using Code.Meta;
using Code.Meta.Features.Simulation;
using Code.Progress.Data;
using Code.Progress.Provider;
using Code.Progress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.States.GameStates
{
  public class ActualizeProgressState : IState
  {
    private readonly IGameStateMachine _stateMachine;
    private readonly ITimeService _time;
    private readonly IProgressProvider _progressProvider;
    private readonly ISystemFactory _systemFactory;
    private ActualizationFeature _actualizationFeature;
    private readonly TimeSpan _twoDays = TimeSpan.FromDays(2);
    private readonly ISaveLoadService _saveLoadService;

    public ActualizeProgressState(
      IGameStateMachine stateMachine,
      ITimeService time,
      IProgressProvider progressProvider,
      ISaveLoadService saveLoadService,
      ISystemFactory systemFactory)
    {
      _saveLoadService = saveLoadService;
      _stateMachine = stateMachine;
      _time = time;
      _progressProvider = progressProvider;
      _systemFactory = systemFactory;
    }
    
    public void Enter()
    {
      _actualizationFeature = _systemFactory.Create<ActualizationFeature>();
      
      ActualizeProgress(_progressProvider.ProgressData);
      
      _stateMachine.Enter<LoadingHomeScreenState>();
    }

    private void ActualizeProgress(ProgressData data)
    {
      _actualizationFeature.Initialize();
      _actualizationFeature.DeactivateReactiveSystems();

      DateTime until = GetLimitedUntilTime(data);

      Debug.Log($"Actualizing {(until - data.LastSimulationTickTime).TotalSeconds} seconds");

      while (data.LastSimulationTickTime < until)
      {
        MetaEntity tick = CreateMetaEntity
          .Empty()
          .AddTick(MetaConstants.SimulationTickSeconds);

        _actualizationFeature.Execute();
        _actualizationFeature.Cleanup();
        
        tick.Destroy();
      }

      data.LastSimulationTickTime = _time.UtcNow;
      _saveLoadService.SaveProgress();
    }

    private DateTime GetLimitedUntilTime(ProgressData data)
    {
      return _time.UtcNow - data.LastSimulationTickTime < _twoDays 
        ? _time.UtcNow 
        : data.LastSimulationTickTime + _twoDays;
    }

    public void Exit()
    {
      _actualizationFeature.Cleanup();
      _actualizationFeature.TearDown();
      _actualizationFeature = null;
    }
  }
}