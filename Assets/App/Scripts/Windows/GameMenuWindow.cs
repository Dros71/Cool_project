using UnityEngine;
using UnityEngine.UI;

public class GameMenuWindow : BaseWindow
{
  public GameData GameData;
  [Space(10)]

  public Button MainMenuButton;
  public Button SettingsButton;

  private void Awake()
  {
    MainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
    SettingsButton.onClick.AddListener(OnSettingsButtonClick);
  }
  
  private void OnMainMenuButtonClick()
  {
    GameData.GameProcess.EndGame();

    GameData.GameMenuWindow.Hide();
    GameData.StartMenuWindow.Show();
  }
  
  private void OnSettingsButtonClick()
  {
    GameData.TransportSettingsWindow.Show();
  }
}
