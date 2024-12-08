using UnityEngine;

namespace App.Scripts.Achiviements
{
  public class AchiviesService
  {
    public void OnTravelLooped(Transport.Transport transport)
    {
      // Логика при проезде круга
      Debug.Log("Travel looped!");
    }
  }
}