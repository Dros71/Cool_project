using System;
using System.Collections.Generic;
using App.Scripts.Achiviements;
using App.Scripts.Transport;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameData : SerializedMonoBehaviour
{
  [BoxGroup("Transport")] public Dictionary<TransportType, TransportData> Transports;

  [BoxGroup("Road")] public SplineDone Spline;
  [BoxGroup("Road")] public Transform TransformSpawnPoint;
  [BoxGroup("Road")] public float RoadLines;
  [BoxGroup("Road")] public float RoadLineWidth;

  [BoxGroup("Windows")] public StartMenuWindow StartMenuWindow;
  [BoxGroup("Windows")] public GameMenuWindow GameMenuWindow;
  [BoxGroup("Windows")] public TransportSettingsWindow TransportSettingsWindow;
  
  [HideInInspector] public GameProcess GameProcess;
  [HideInInspector] public TransportContainer TransportContainer;
  [HideInInspector] public LogService LogService;

  private void Awake()
  {
    TransportContainer = new TransportContainer(this);
    LogService = new LogService();
    
    GameProcess = new GameProcess(this, TransportContainer, LogService);
  }

  private void Update()
  {
    GameProcess.OnUpdate();
  }
}