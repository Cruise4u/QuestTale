using UnityEngine;
using DG.Tweening;
using AbilityInterface;

[CreateAssetMenu(menuName = "AI Skills/Throw Ally", order = 2)]
public class ThrowAlly : AbilityPrototype,IAbilityLauncher
{
    public void ThrowAllyToPosition(GameObject self,GameObject target,GameObject ammo)
    {
        ammo.transform.DOJump(target.transform.position, 3.0f, 1, 1.0f);
    }
    
    public override void CastAbility(GameObject caster, int behaviour)
    {
        switch (behaviour)
        {
            case 0:
                //ThrowAllyToPosition(caster)
                break;

            case 1:

                break;
        }
    }

    public override void SetIndicatorController(GameObject caster)
    {
        
    }

    public void LaunchAbility(GameObject launcher)
    {

    }
}