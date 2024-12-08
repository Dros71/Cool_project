using System.Collections.Generic;
using App.Scripts.Achiviements;
using App.Scripts.Transport;
using UnityEngine;

public class GameProcess
{
  private readonly GameData _gameData;
  private readonly TransportContainer _transportContainer;
  private readonly AchiviesService _achiviesService;
  
  private int _currentRoadLine = 1;

  public GameProcess(GameData gameData, TransportContainer transportContainer, AchiviesService achiviesService)
  {
    _gameData = gameData;
    _transportContainer = transportContainer;
    _achiviesService = achiviesService;
  }

  public void StartGame()
  {
    
    Debug.Log("Game Started!");
  }

  public void EndGame()
  {
    _transportContainer.DespawnAllTransports();
    
    Debug.Log("Game Ended!");
  }

  public void OnUpdate()
  {
    foreach (Transport transport in _transportContainer.Transports)
    {
      if (transport.FuelLeft <= 0 || transport.FuelLeft / transport.FuelUse < transport.SplineFollower.LoopPercent)
        transport.SplineFollower.IsMovementAvailable = false;
    }
  }

  public Transport SpawnAndSetupTransport(TransportType transportType)
  {
    Transport transport = _transportContainer.SpawnTransport(transportType);
    
    transport.Setup(transportType, _gameData.Spline, _gameData.Transports[transportType].Speed, _gameData.Transports[transportType].FuelUse, _gameData.Transports[transportType].FuelCapacity, GetRoadLineDelta(_currentRoadLine++) , SplineFollower.MovementType.Units);
    transport.TraveledLoop += () => _achiviesService.OnTravelLooped(transport);
    transport.TraveledLoop += transport.SpendFuelLoop;
    
    return transport;
  }
  
  public void DespawnTransport(TransportType transportType)
  {
    _transportContainer.DespawnTransport(transportType);
  }

  private float GetRoadLineDelta(int line)
  {
    return (((line - 1) - _gameData.RoadLines / 2f) + 0.5f) * _gameData.RoadLineWidth;
  }
}
