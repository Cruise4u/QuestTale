using UnityEngine;
using System;

public class PlayerStats : UnitStatss
{
    /* 
    public bool IsBehindTarget(GameObject target)
    {
        Vector3 targetDirection = (transform.position - target.transform.position).normalized;
        float dot = Vector3.Dot(targetDirection, transform.forward);
        if (dot <= -0.6f && dot >= -1.0f)
        {
            Debug.Log("Behind Target !");
            return true;
        }
        else
        {
            Debug.Log("In front of target!");
            return false;
        }
    }
    */

    /*
    public int DealDoubleDamage()
    {
        return attackPower * 2;
    }
    */

    public bool IsTargetDestroyed()
    {
        return unitTarget = unitTarget.GetComponent<UnitStatss>().isAlive ? unitTarget : null;
    }

    public bool isStealthed = false;

    public bool IsPlayerOnStealthMode()
    {
        return isStealthed;
    }
}
