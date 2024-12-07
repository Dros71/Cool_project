using UnityEngine;
using UnityEngine.UI;

public class StartMenuWindow : BaseWindow
{
  public GameData GameData;
  [Space(10)]

  public Button StartButton;
  public Button CloseButtonWindow;

  private void Awake()
  {
    StartButton.onClick.AddListener(OnStartButtonClick);
    CloseButtonWindow.onClick.AddListener(OnCloseButtonClick);
  }

  
  private void OnStartButtonClick()
  {
    GameData.GameProcess.StartGame();

    GameData.StartMenuWindow.Hide();
    GameData.GameMenuWindow.Show();
  }

  private void OnCloseButtonClick()
  {
    Application.Quit();
  }
}
