using System.Collections.Generic;
using UnityEngine;

public class GameProcess
{
  private Dictionary<TransportType, Transport> _transportsGameObjects = new();
  
  private readonly GameData _gameData;

  public GameProcess(GameData gameData)
  {
    _gameData = gameData;
  }

  public void StartGame()
  {
    
    
    Debug.Log("Game Started!");
  }

  public void EndGame()
  {
    DespawnAllTransports();
    
    Debug.Log("Game Ended!");
  }
  
  public void SpawnTransport(TransportType transportType, int line = 0)
  {
    _transportsGameObjects.Add(
      transportType,
      SpawnAndSetupTransport(transportType));
  }

  public void DespawnTransport(TransportType transportType)
  {
    if (_transportsGameObjects.ContainsKey(transportType))
    {
      GameObject.Destroy(_transportsGameObjects[transportType]);
      _transportsGameObjects.Remove(transportType);
    }
  }

  public void DespawnAllTransports()
  {
    foreach (var transport in _transportsGameObjects) 
      GameObject.Destroy(transport.Value);
    
    _transportsGameObjects.Clear();
  }
  
  private Transport SpawnAndSetupTransport(TransportType transportType)
  {
    Transport transport = GameObject.Instantiate(_gameData.Transports[transportType].Transport, _gameData.TransformSpawnPoint.position, Quaternion.identity);
    transport.Setup(_gameData.Spline, _gameData.Transports[transportType].Speed, Random.Range(1, _gameData.RoadLines+1), SplineFollower.MovementType.Units);
    
    return transport;
  }
}
