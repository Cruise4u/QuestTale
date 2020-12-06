using System;
using UnityEngine;
using DG.Tweening;

public class UnitMovementAndRotation
{
    public Vector3 moveLocation;

    public void SetLocation(Vector3 location)
    {
        moveLocation = location;
    }

    public void RotateToTarget()
    {

    }

    public void ChaseTarget()
    {

    }

    public void StopMoving()
    {

    }

    public bool GetDistanceToTarget(Vector3 position,float range)
    {
        bool isInRange = false;
        if(Vector3.Distance(moveLocation,position) <= range)
        {
            isInRange = true;
        }
        else
        {
            isInRange = false;
        }
        return isInRange;
    }
}
