using System;
using UnityEngine;

[CreateAssetMenu(menuName = "AI Skills/Blink", order = 6)]
public class Blink : AbilityPrototype
{
    public void BlinkToPoint(GameObject caster)
    {
        var target = caster.GetComponent<UnitStatss>().unitTarget;
        Vector3 directionToCaster = caster.transform.position - target.transform.position;
        Vector3 directionNormalized = directionToCaster.normalized;
        Vector2 desiredPosition = new Vector3(directionNormalized.x * 2.5f, directionToCaster.y, directionNormalized.z * 2.5f);
        // It is possible to implement Tweening instead..
        caster.transform.position = Vector3.Lerp(caster.transform.position, desiredPosition, 0.75f);
    }

    public override void CastAbility(GameObject caster, int behaviour)
    {
        switch (behaviour)
        {
            case 0:
                BlinkToPoint(caster);
                break;
        }
    }

    public override void SetIndicatorController(GameObject caster)
    {
        
    }


}