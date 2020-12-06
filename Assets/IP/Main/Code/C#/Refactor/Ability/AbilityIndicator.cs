using System;
using UnityEngine;

public class AbilityIndicator : MonoBehaviour
{
    public GameObject caster;
    public GameObject indicatorController;

    public void SetupIndicators()
    {
        caster = gameObject;
        GetChildObjectByTag("Indicator");
    }

    public void GetChildObjectByTag(string tag)
    {
        int childNumber = caster.transform.childCount;
        Debug.Log(childNumber);
        GameObject[] childObjects = new GameObject[childNumber];
        for (int i = 0; i < childNumber; i++)
        {
            var childTransform = caster.transform.GetChild(i);
            childObjects[i] = childTransform.gameObject;
            if (childObjects[i].CompareTag(tag))
            {
                indicatorController = childObjects[i];
            }
        }
    }

    public void ToggleIndicator()
    {
        if (indicatorController.activeInHierarchy == true)
        {
            indicatorController.SetActive(false);
        }
        else
        {
            indicatorController.SetActive(true);
        }
    }

    // Geometric functions for controlling the indicator direciton/position/etc.
    public void SetIndicatorDirection(Camera camera)
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Vector3 indicatorPosition = new Vector3(hit.point.x, 0.0f, hit.point.z);
            SetIndicatorPosition(caster.transform.position, indicatorPosition);
        }
    }

    public void SetIndicatorPosition(Vector3 basePoint, Vector3 hitPoint)
    {
        Vector3 normalizedPoint = (hitPoint - basePoint).normalized;
        indicatorController.transform.rotation = GetDirectionalRotation(normalizedPoint);
    }

    public float GetAngle(Vector3 point)
    {
        float angle = (Mathf.Atan2(point.x, point.z) / Mathf.PI) * 180f;
        if (angle < 0.0f)
        {
            angle += 360f;
        }
        return angle;
    }

    public Quaternion GetDirectionalRotation(Vector3 normalizedVector)
    {
        float angle = GetAngle(normalizedVector);
        Quaternion newRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        return newRotation;
    }

}
