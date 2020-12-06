using System;
using UnityEngine;

public class AbilityColliderDetector : MonoBehaviour
{
    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other);
    }

    public void OnBeingInsideTheCone()
    {
        Debug.Log("Target is inside area!");
    }
}
