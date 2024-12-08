using UnityEngine;

public class Transport : MonoBehaviour
{
  public SplineFollower SplineFollower;

  
  public void Setup(SplineDone spline, float speed, SplineFollower.MovementType movementType)
  {
    SplineFollower.Setup(spline, speed, movementType);
  }
}