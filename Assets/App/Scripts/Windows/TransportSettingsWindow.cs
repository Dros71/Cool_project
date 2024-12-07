using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportSettingsWindow : BaseWindow
{
  public GameData GameData;
  [Space(10)]
  
  public Button CloseButton;
  public Dictionary<TransportType, Toggle> SpawnButtons;
  

  private void Awake()
  {
    CloseButton.onClick.AddListener(OnCloseButtonClick);

    foreach (var button in SpawnButtons) 
      button.Value.onValueChanged.AddListener((_) => OnSpawnButtonValueChanged(button.Key, button.Value.isOn));
  }

  public void Show()
  {
    gameObject.SetActive(true);
  }
  
  private void OnCloseButtonClick()
  {
    gameObject.SetActive(false);
  }

  private void OnSpawnButtonValueChanged(TransportType transportType, bool value)
  {
    if (value)
      GameData.GameProcess.SpawnTransport(transportType);
    else
      GameData.GameProcess.DespawnTransport(transportType);
  }
}
