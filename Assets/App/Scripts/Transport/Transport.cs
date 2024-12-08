using System;
using UnityEngine;

namespace App.Scripts.Transport
{
  public class Transport : MonoBehaviour
  {
    public SplineFollower SplineFollower;
    public GameObject View;
  
    public event Action TraveledLoop;

    private void Awake()
    {
      SplineFollower.TraveledLoop += () => TraveledLoop?.Invoke();
    }

    public void Setup(SplineDone spline, float speed, float xDelta, SplineFollower.MovementType movementType)
    {
      View.transform.localPosition = View.transform.localPosition.AddX(xDelta);
      SplineFollower.Setup(spline, speed, movementType);
    }
  }
}