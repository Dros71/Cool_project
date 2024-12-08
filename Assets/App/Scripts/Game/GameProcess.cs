using System.Collections.Generic;
using App.Scripts.Achiviements;
using App.Scripts.Transport;
using UnityEngine;

public class GameProcess
{
  private readonly GameData _gameData;
  private readonly TransportContainer _transportContainer;
  private readonly AchiviesService _achiviesService;

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


  public Transport SpawnAndSetupTransport(TransportType transportType)
  {
    Transport transport = _transportContainer.SpawnTransport(transportType);
    
    transport.Setup(_gameData.Spline, _gameData.Transports[transportType].Speed, GetRoadLineDelta(1) , SplineFollower.MovementType.Units);
    transport.TraveledLoop += () => _achiviesService.OnTravelLooped(transport);
    
    return transport;
  }
  
  public void DespawnTransport(TransportType transportType)
  {
    _transportContainer.DespawnTransport(transportType);
  }

  private float GetRoadLineDelta(int line)
  {
    return ((_gameData.RoadLines + 1 - line) - (_gameData.RoadLines / 2) * _gameData.RoadLineWidth + (_gameData.RoadLineWidth / 2));
  }
}
