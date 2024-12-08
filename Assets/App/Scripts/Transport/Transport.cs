using UnityEngine;

public class Transport : MonoBehaviour
{
  public SplineFollower SplineFollower;
  public GameObject View;
  
  public void Setup(SplineDone spline, float speed, float xDelta, SplineFollower.MovementType movementType)
  {
    View.transform.localPosition.AddX(xDelta);
    SplineFollower.Setup(spline, speed, movementType);
  }
}