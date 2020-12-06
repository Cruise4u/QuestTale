using System;
using UnityEngine;
using Bolt;
using UnityEngine.AI;
using InterfaceLibrary;
using DG.Tweening;
using AbilityInterface;
using EuclideanInterface;

public enum RotationTarget
{
    Point,
    Agent,
}

public class UnitActionsss : MonoBehaviour, IDamager, IMove, IRotate, IDistance
{
    public Vector3 newDestination;
    public RotationTarget rotationTarget;

    public void UpdateTargetPosition()
    {
        var stats = gameObject.GetComponent<UnitStatss>();
        if (stats.unitTarget != null && stats.unitTarget.CompareTag("enemy"))
        {
            newDestination = stats.unitTarget.transform.position;
        }
    }

    public void UpdateRotation(float rotationSpeed)
    {
        if(rotationTarget == RotationTarget.Agent)
        {
            var target = gameObject.GetComponent<UnitStatss>().unitTarget;
            gameObject.transform.rotation = GetRotatioToTarget(target, rotationSpeed);
        }
        else if(rotationTarget == RotationTarget.Point)
        {
            gameObject.transform.rotation = GetRotationToPoint(newDestination, rotationSpeed);
        }
    }

    public void DealDamage(IDamagable damagable)
    {
        var attackDamage = gameObject.GetComponent<UnitStatss>().attackPower;
        damagable.TakeDamage(attackDamage);
    }

    public bool GetDistanceToTarget(GameObject target, float threshold)
    {
        bool booleanParameter;
        // Checks the distance between 2 objects..
        float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        // And set's the value of the boolean to either true or false based on the threshold..
        if (distance <= threshold)
        {
            booleanParameter = true;
        }
        else
        {
            booleanParameter = false;
        }
        //Returns if the distance to an object is higher or less than a certain threshold..
        return booleanParameter;
    }

    public bool IsTargetNotInDistanceToAttack(GameObject target, float minimum)
    {
        bool isWithingRange;
        // Checks the distance between 2 objects..
        float distance = Vector3.Distance(gameObject.transform.position, target.transform.position);
        // And set's the value of the boolean to either true or false based on the threshold..
        if (distance <= minimum)
        {
            isWithingRange = false;
        }
        else
        {
            isWithingRange = true;
        }
        //Returns if the distance to an object is higher or less than a certain threshold..
        return isWithingRange;
    }

    public void Move(IMovable movable, int behaviour)
    {
        movable = gameObject.GetComponent<IMovable>();
        switch (behaviour)
        {
            case 0:
                movable.MoveToDestination(newDestination);
                break;

            case 1:
                movable.StopMoving();
                break;
        }
    }

    public Quaternion GetRotationToPoint(Vector3 point, float rotationSpeed)
    {
        var agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        Vector3 direction = (newDestination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        Quaternion newRotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        return newRotation;
    }

    public Quaternion GetRotatioToTarget(GameObject target,float rotationSpeed)
    {
        var agent = gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        Vector3 direction = (target.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));
        Quaternion newRotation = Quaternion.Slerp(agent.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        return newRotation;
    }

}
