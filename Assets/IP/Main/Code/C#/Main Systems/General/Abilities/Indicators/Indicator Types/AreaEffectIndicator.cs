using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability Indicator/ AOE Indicator")]
public class AreaEffectIndicator : IndicatorPrototype
{
    public override void SetIndicatorPosition(GameObject obj,Vector3 point)
    {
        obj.transform.position = new Vector3(point.x,1.0f,point.z);
    }

}


