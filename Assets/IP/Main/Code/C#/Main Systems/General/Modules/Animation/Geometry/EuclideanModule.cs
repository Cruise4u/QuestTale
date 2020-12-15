using System;
using UnityEngine;

namespace EuclideanInterface
{
    public interface IRotate
    {
        void UpdateRotation(float rotationSpeed);
    }

    public interface IDistance
    {
        bool GetDistanceToTarget(GameObject target, float threshold);
    }




}