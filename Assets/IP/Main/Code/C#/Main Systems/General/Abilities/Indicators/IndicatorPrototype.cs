using System;
using UnityEngine;

// Base class for all other indicator types : Aoe,SkillShot,Single-target(Buff/Unbuff),Etc.
public abstract class IndicatorPrototype : ScriptableObject
{
    public GameObject Prefab;

    public abstract void SetIndicatorPosition(GameObject obj, Vector3 point);

    public virtual void UpdateIndicatorPosition(GameObject obj)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            Vector3 newPoint = new Vector3(hit.point.x, 0.5f, hit.point.z);
            SetIndicatorPosition(obj, newPoint);
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 100.0f);
        }
    }

    public virtual void SetIndicatorAsChild(GameObject obj, GameObject parent)
    {
        obj.transform.SetParent(parent.transform);
    }

    public virtual GameObject[] GetChildIndicators()
    {
        GameObject[] childIndicators = new GameObject[Prefab.transform.childCount];
        if (Prefab.transform.childCount > 0)
        {
            for (int i = 0; i < childIndicators.Length; i++)
            {
                childIndicators[i] = Prefab.transform.GetChild(i).gameObject;
            }
            return childIndicators;
        }
        else
        {
            childIndicators = new GameObject[0];
            return childIndicators;
        }
    }
}
