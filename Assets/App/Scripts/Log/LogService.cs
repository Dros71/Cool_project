using UnityEngine;

namespace App.Scripts.Achiviements
{
  public class LogService
  {
    public void OnTravelLooped(Transport.Transport transport)
    {
      // Логика при проезде круга
      Debug.Log("Travel looped!");
    }
    
    public void FuelConsumed(Transport.Transport transport)
    {
      // Логика при конце топлива
      Debug.Log("Fuel consumed!");
    }
  }
}