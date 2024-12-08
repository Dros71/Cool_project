using System;
using System.IO;
using UnityEngine;

namespace App.Scripts.Achiviements
{
  public class LogService
  {
    public void OnTravelLooped(Transport.Transport transport)
    {
       string filePath = Path.Combine(Application.dataPath, "LapTimes.txt");

        string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        File.AppendAllText(filePath, "Текущий круг проехал" + transport + currentTime + Environment.NewLine);
        Debug.Log("Lap time recorded: " + currentTime);
        Debug.Log("Travel looped!");
    }
  
    
    public void FuelConsumed(Transport.Transport transport)
    {
      // Логика при конце топлива
      string filePath = Path.Combine(Application.dataPath, "Fuel.txt");

        File.AppendAllText(filePath, "У " + transport + " топливо закончилось " + Environment.NewLine);

      Debug.Log("Fuel consumed!");
    }
  }
}