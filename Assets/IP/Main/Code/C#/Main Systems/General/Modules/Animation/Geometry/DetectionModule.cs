using Bolt;
using System;
using UnityEngine;

public class DetectionModule : MonoBehaviour
{
    Vector3[] detectionalVectors;
    int numberOfRays;
    public GameObject detectionProbe;
    public int angle;
    public bool IsTargetOnSight;
    public string detectionTag;
    public LayerMask playerMask;

    LineRenderer lr;
    
    public void FixedUpdate()
    {
        if(IsTargetOnSight == true)
        {
            GetClosestEnemy(5.0f);
        }
    }

    public Vector3 GetVectorRotatedPosition(Vector3 vector, int angle)
    {
        float xAngle = vector.x * Mathf.Cos(angle * Mathf.Deg2Rad) - vector.z * Mathf.Sin(angle * Mathf.Deg2Rad);
        float zAngle = vector.x * Mathf.Sin(angle * Mathf.Deg2Rad) + vector.z * Mathf.Cos(angle * Mathf.Deg2Rad);
        return new Vector3(xAngle, 1.0f, zAngle);
    }

    public void GetDetectionRaysMovementUpdate(int angle)
    {
        Vector3 directionalVector = (detectionProbe.transform.position - gameObject.transform.position);
        for (int i = 0; i < detectionalVectors.Length; i++)
        {
            int tempAngle = angle * i;
            detectionalVectors[i] = GetVectorRotatedPosition(directionalVector, tempAngle);
            CheckIfTargetGotCaught(detectionalVectors[i],directionalVector.magnitude);
        }
    }

    public bool CheckIfTargetGotCaught(Vector3 direction, float radius)
    {
        RaycastHit hit;
        var stats = gameObject.GetComponent<UnitStatss>();

        if(Physics.Raycast(gameObject.transform.position, direction, out hit, stats.sightRange))
        {
            if (hit.collider.gameObject.CompareTag("player"))
            {
                IsTargetOnSight = true;
            }
            if (hit.collider.gameObject.CompareTag("enemy"))
            {
                GetClosestAlly(10.0f);
            }
        }

        return IsTargetOnSight;
    }

    public void GetClosestEnemy(float radius)
    {
        if(IsTargetOnSight != false)
        {
            Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position,radius);
            float temporaryDistance = 100.0f;
            foreach (Collider col in colliders)
            {
                if (col.gameObject.CompareTag("player"))
                {
                    float currentDistance = Vector3.Distance(gameObject.transform.position, col.transform.position);
                    if (temporaryDistance > currentDistance)
                    {
                        temporaryDistance = currentDistance;
                        gameObject.GetComponent<UnitStatss>().unitTarget = col.gameObject;
                    }
                }
            }
        }
    }

    public void GetClosestAlly(float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, radius);
        float temporaryDistance = 100.0f;
        foreach (Collider col in colliders)
        {
            if (col.gameObject.CompareTag("enemy"))
            {
                float currentDistance = Vector3.Distance(gameObject.transform.position, col.transform.position);
                if (temporaryDistance > currentDistance)
                {
                    temporaryDistance = currentDistance;
                    gameObject.GetComponent<EnemyStats>().closestAlly = col.gameObject;
                }
            }
        }
    }

    public void SetupDetection()
    {
        IsTargetOnSight = false;
        numberOfRays = (360 / angle);
        detectionalVectors = new Vector3[numberOfRays - 1];
        lr = gameObject.GetComponent<LineRenderer>();
    }

}
