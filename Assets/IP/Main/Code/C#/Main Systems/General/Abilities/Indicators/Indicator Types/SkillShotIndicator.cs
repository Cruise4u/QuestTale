using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability Indicator/ Skillshot Indicator")]
public class SkillShotIndicator : IndicatorPrototype
{
    public override void SetIndicatorPosition(GameObject obj, Vector3 point)
    {
        Vector3 normalizedPoint = (point - obj.transform.position).normalized;
        SetDirectionFromRotation(obj, normalizedPoint);
    }

    public float GetAngle(Vector3 otherPoint)
    {
        float angle = (Mathf.Atan2(otherPoint.x, otherPoint.z) / Mathf.PI) * 180f;
        if (angle < 0.0f)
        {
            angle += 360f;
        }
        return angle;
    }

    public void SetDirectionFromRotation(GameObject obj, Vector3 normalized)
    {
        float angle = GetAngle(normalized);
        Quaternion newRotation = Quaternion.Euler(0.0f, angle, 0.0f);
        var numOfChilds = obj.transform.childCount;
        var indicator = obj.transform.GetChild(numOfChilds - 1);
        indicator.transform.rotation = newRotation;
    }
}
