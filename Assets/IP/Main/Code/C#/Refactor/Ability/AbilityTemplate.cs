using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AbilityStatistics
{
    public string AbilityName;
    public int AbilityPower;
    public int AbilityRange;
    public int AbilityCost;
    public float AbilityCooldown;
}

public abstract class AbilityTemplate
{
    public AbilityStatistics abilityStatistics;
    public abstract void CastAbility();
    public abstract void Setup(AbilityData data);

    public abstract void ResetCooldown();

    public abstract void SetCooldown(AbilityData data);
}


public class PlayerAbilityTwo : AbilityTemplate
{
    public override void CastAbility()
    {
        throw new System.NotImplementedException();
    }

    public override void ResetCooldown()
    {
        abilityStatistics.AbilityCooldown = 0;
    }

    public override void SetCooldown(AbilityData data)
    {
        abilityStatistics.AbilityCooldown = data._abilityCooldown;
    }

    public override void Setup(AbilityData data)
    {
        throw new System.NotImplementedException();
    }
}
