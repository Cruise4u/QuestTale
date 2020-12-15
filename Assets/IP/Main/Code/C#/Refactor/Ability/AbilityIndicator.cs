using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class AbilityIndicator : ScriptableObject
{
    public GameObject indicatorPrefab;
    public GameObject caster;

    public virtual void SetIndicatorPosition(GameObject indicator)
    {

    }

    public virtual void SetIndicatorDirection(GameObject indicator,Camera playerCamera)
    {

    }

    public virtual void SetIndicatorRotation(GameObject indicator,Vector3 hitPosition)
    {

    }

    public virtual void ToggleIndicator(GameObject indicator)
    {
        if(indicator == true)
        {
            indicator.SetActive(false);
        }
        else if(indicator == false)
        {
            indicator.SetActive(true);
        }
    }
}

[CreateAssetMenu(menuName = "Ability/Indicators/Cone")]
public class ConeIndicator : AbilityIndicator
{
    public AbilityIndicator CreateIndicator()
    {
        var cone = CreateInstance<ConeIndicator>();
        return cone;
    }

    public override void SetIndicatorPosition(GameObject indicator)
    {
        indicator.transform.SetParent(caster.transform);
        indicator.transform.localPosition = Vector3.zero;
    }

    public override void SetIndicatorDirection(GameObject indicator,Camera playerCamera)
    {
        RaycastHit hit;
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Vector3 indicatorPosition = new Vector3(hit.point.x, 0.0f, hit.point.z);
            SetIndicatorRotation(indicator,indicatorPosition);
        }
    }

    public override void SetIndicatorRotation(GameObject indicator,Vector3 hitPosition)
    {
        Vector3 normalizedPoint = (hitPosition - caster.transform.position).normalized;
        indicator.transform.rotation = GetRotation(normalizedPoint);
    }

    public Quaternion GetRotation(Vector3 normalizedVector)
    {
        float angle = GetAngle(normalizedVector);
        Quaternion newRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        return newRotation;
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

}
