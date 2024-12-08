using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.Scripts.Transport
{
  public class TransportContainer
  {
    public List<Transport> Transports => _transportsGameObjects.Values.ToList(); 

    private Dictionary<TransportType, Transport> _transportsGameObjects = new();
    
    private readonly GameData _gameData;

    public TransportContainer(GameData gameData)
    {
      _gameData = gameData;
    }
    
    public Transport SpawnTransport(TransportType transportType)
    {
      var transport = SpawnTransportGameObject(transportType);
      
      _transportsGameObjects.Add(
        transportType,
        transport);

      return transport;
    }
    
    private Transport SpawnTransportGameObject(TransportType transportType)
    {
      return GameObject.Instantiate(_gameData.Transports[transportType].Transport, _gameData.TransformSpawnPoint.position, Quaternion.identity);
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
}