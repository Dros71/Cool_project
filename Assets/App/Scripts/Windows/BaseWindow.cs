using Sirenix.OdinInspector;

public class BaseWindow : SerializedMonoBehaviour
{
  public void Show()
  {
    gameObject.SetActive(true);
  }

  public void Hide()
  {
    gameObject.SetActive(false);
  }
}
