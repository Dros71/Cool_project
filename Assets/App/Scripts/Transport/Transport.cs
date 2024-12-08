using System;
using UnityEngine;

namespace App.Scripts.Transport
{
  public class Transport : MonoBehaviour
  {
    public SplineFollower SplineFollower;
    public GameObject View;

    private TransportType _transportType;

    public event Action TraveledLoop;

    private void Awake()
    {
      SplineFollower.TraveledLoop += () => TraveledLoop?.Invoke();
    }

    public void Setup(TransportType transportType, SplineDone spline, float speed, float xDelta, SplineFollower.MovementType movementType)
    {
      _transportType = transportType;
      View.transform.localPosition = View.transform.localPosition.AddX(xDelta);
      SplineFollower.Setup(spline, speed, movementType);
    }

    public override string ToString() => _transportType.ToString();
  }
}