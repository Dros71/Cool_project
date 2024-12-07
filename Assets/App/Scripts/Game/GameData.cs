using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameData : SerializedMonoBehaviour
{
  [BoxGroup("Transport")] public Dictionary<TransportType, TransportData> Transports;
  [BoxGroup("Transport")] public SplineDone Spline;
  [BoxGroup("Transport")] public Transform TransformSpawnPoint;

  [BoxGroup("Windows")] public StartMenuWindow StartMenuWindow;
  [BoxGroup("Windows")] public GameMenuWindow GameMenuWindow;
  [BoxGroup("Windows")] public TransportSettingsWindow TransportSettingsWindow;
  
  [HideInInspector] public GameProcess GameProcess;

  private void Awake()
  {
    GameProcess = new GameProcess(this);
  }
  

}