using System.Collections.Generic;
using UnityEngine;

public class GameProcess
{
  private Dictionary<TransportType, GameObject> _transportsGameObjects = new();
  
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
  
  public void SpawnTransport(TransportType transportType)
  {
    _transportsGameObjects.Add(
      transportType,
      GameObject.Instantiate(_gameData.TransportPrefabs[transportType], _gameData.TransformSpawnPoint.position, Quaternion.identity));
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
}
