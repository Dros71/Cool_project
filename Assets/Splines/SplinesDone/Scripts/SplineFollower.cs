using System;
using UnityEngine;

public class SplineFollower : MonoBehaviour {

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

        switch (_movementType) {
            default:
            case MovementType.Normalized:
                transform.position = _spline.GetPositionAt(moveAmount);
                transform.forward = _spline.GetForwardAt(moveAmount);
                break;
            case MovementType.Units:
                transform.position = _spline.GetPositionAtUnits(moveAmount);
                transform.forward = _spline.GetForwardAtUnits(moveAmount);
                break;
        }
    }

    public void Setup(SplineDone spline, float speed, MovementType movementType)
    {
        _speed = speed;
        _spline = spline;
        _movementType = movementType;
    }
}
