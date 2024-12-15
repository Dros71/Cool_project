using System;
using UnityEngine;

public class SplineFollower : MonoBehaviour {
    
    private const float Epsilon = 0.01f;

    public enum MovementType {
        Normalized,
        Units
    }
    
    public event Action TraveledLoop;
    
    public float LoopPercent => moveAmount / maxMoveAmount;
    public bool IsMovementAvailable = true;
    

    private SplineDone _spline;
    private float _speed = 1f;
    private MovementType _movementType;

    private float moveAmount;
    private float maxMoveAmount;

    private void Start() {
        switch (_movementType) {
            default:
            case MovementType.Normalized:
                maxMoveAmount = 1f;
                break;
            case MovementType.Units:
                maxMoveAmount = _spline.GetSplineLength();
                break;
        }
    }

    private void Update() 
    {
        if(IsMovementAvailable == false) return;

        float delta = Time.deltaTime * _speed;
        var amount = moveAmount + delta;
        
        if(amount >= maxMoveAmount) 
            TraveledLoop?.Invoke();
        
        moveAmount = amount % maxMoveAmount;

        SetPositionByMovementAmount(moveAmount);
    }

    public void Setup(SplineDone spline, float speed, MovementType movementType)
    {
        _speed = speed;
        _spline = spline;
        _movementType = movementType;
        
        SetPositionByMovementAmount(Epsilon);
    }
    
    private void SetPositionByMovementAmount(float amount)
    {
        switch (_movementType) {
            default:
            case MovementType.Normalized:
                transform.position = _spline.GetPositionAt(amount);
                transform.forward = _spline.GetForwardAt(amount);
                break;
            case MovementType.Units:
                transform.position = _spline.GetPositionAtUnits(amount);
                transform.forward = _spline.GetForwardAtUnits(amount);
                break;
        }
    }
}
