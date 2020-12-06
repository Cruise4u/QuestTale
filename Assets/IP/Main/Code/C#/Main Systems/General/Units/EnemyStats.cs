using UnityEngine;
using UnityEngine.AI;
using System;
using InterfaceLibrary;

public class EnemyStats : UnitStatss,IMarkable
{
    public Collider GetCollider { get => gameObject.GetComponent<Collider>(); }
    public bool IsMarked { get; set; }

    public GameObject closestAlly;

    public void Start()
    {
        Unmarked();
    }

    public void SetClosestAlly()
    {
        float distance = 0.0f;
        Collider[] allyColliders = Physics.OverlapSphere(gameObject.transform.position, 5.5f);
        foreach (Collider col in allyColliders)
        {
            if (col.gameObject != gameObject)
            {
                if (col.gameObject.CompareTag("enemy"))
                {
                    var tempDistance = Vector3.Distance(gameObject.transform.position, col.gameObject.transform.position);
                    if (distance <= tempDistance)
                    {
                        distance = tempDistance;
                        closestAlly = col.gameObject;
                    }
                }
            }
        }
    }

    public void Marked()
    {
        IsMarked = true;
    }

    public void Unmarked()
    {
        IsMarked = false;
    }

    public bool CheckIfTargetIsNull()
    {
        bool isTargetNull;
        var player = GameObject.Find("player");
        if (unitTarget == null)
        {
            isTargetNull = true;
            unitTarget = player;
        }
        else
        {
            isTargetNull = false;
        }
        return isTargetNull;
    }

}
