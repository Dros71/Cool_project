using System;
using UnityEngine;

namespace App.Scripts.Transport
{
  public class Transport : MonoBehaviour
  {
    public SplineFollower SplineFollower;
    public GameObject View;
    
    private TransportType _transportType;

    public float FuelUse { get; private set; }
    public float FuelLeft { get; private set; }
    
    public event Action TraveledLoop;

    private void Awake()
    {
      SplineFollower.TraveledLoop += () => TraveledLoop?.Invoke();
    }

    public void SpendFuelLoop() => FuelLeft -= FuelUse;

    public void Setup(TransportType transportType, SplineDone spline, float speed, float fuelUse, float fuelCapacity, float xDelta, SplineFollower.MovementType movementType)
    {
      _transportType = transportType;
      View.transform.localPosition = View.transform.localPosition.AddX(xDelta);
      SplineFollower.Setup(spline, speed, movementType);

      FuelLeft = fuelCapacity;
      FuelUse = fuelUse;
    }

    public override string ToString() => _transportType.ToString();
  }
}