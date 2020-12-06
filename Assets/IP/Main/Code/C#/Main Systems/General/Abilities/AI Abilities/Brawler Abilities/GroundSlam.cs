using System;
using AbilityInterface;
using Bolt;
using DG.Tweening;
using UnityEngine;
using EuclideanInterface;
using InterfaceLibrary;

[CreateAssetMenu(menuName = "AI Skills/Ground Slam", order = 1)]
public class GroundSlam : AbilityPrototype, IAbilityWarning
{
    public override void CastAbility(GameObject caster, int behaviour)
    {
        switch (behaviour)
        {
            case 0:
                SmashGround(caster);
                break;
            case 1:

                break;
        }
    }

    public override void SetIndicatorController(GameObject caster)
    {
        throw new NotImplementedException();
    }

    public void SmashGround(GameObject caster)
    {
        RaycastHit hit;
        var forwardDirection = caster.transform.forward * abilityStats.abilityRange;
        var newDirection = new Vector3(forwardDirection.x, caster.transform.position.y, forwardDirection.z);
        if (Physics.BoxCast(caster.transform.position, caster.transform.lossyScale / 2, newDirection, out hit))
        {
            if (hit.collider.gameObject.CompareTag("player"))
            {
                PullTargetOnImpact(caster, hit.collider.gameObject, hit.point);
                CustomEvent.Trigger(hit.collider.gameObject, "TakeDamageEvent", abilityStats.abilityPower);
            }
        }
    }

    public void PullTargetOnImpact(GameObject self, GameObject target, Vector3 position)
    {
        position = self.transform.position - position;
        Vector3 offset = self.GetComponent<Rigidbody>().ClosestPointOnBounds(position);
        Vector3 newPosition = new Vector3(offset.x, target.transform.position.y, offset.z);
        target.transform.DOJump(newPosition, 2.0f, 1, 1.0f, false);
        CustomEvent.Trigger(target, "Stun", true);
    }

    public void DisplayDangerZone(GameObject caster,float range)
    {
        var lr = caster.GetComponent<LineRenderer>();
        var point = lr.GetPosition(1);
        var pointAmount = lr.GetPosition(1).z + 0.1f;
        float clampedValue = Mathf.Clamp(pointAmount, 0.1f, range);
        var newPoint = new Vector3(point.x, 0.25f, clampedValue);
        lr.SetPosition(1, newPoint);
    }

    public void ToggleWarning(GameObject caster)
    {
        var lr = caster.GetComponent<LineRenderer>();
        if(lr.enabled == true)
        {
            lr.enabled = false;
        }
        else
        {
            lr.enabled = true;
        }
    }

    public void RestartWarning(GameObject caster)
    {
        var lr = caster.GetComponent<LineRenderer>();
        var point = lr.GetPosition(1);
        var resetPoint = new Vector3(point.x, point.y, 0.1f);
        lr.SetPosition(1, resetPoint);
    }
}