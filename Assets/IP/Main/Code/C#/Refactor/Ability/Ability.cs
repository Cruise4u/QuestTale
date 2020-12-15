using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct AbilityStatistics
{
    public string abilityName;
    public int abilityPower;
    public int abilityRange;
    public int abilityCost;
    public float abilityCooldown;
}

public abstract class Ability : ScriptableObject
{
    public string abilityName;
    public AbilityData abilityConfigData;
    //public AbilityStatistics abilityStats;
    public AbilityIndicator abilityIndicator;

    //public void SetupAbilityStats(AbilityData abilityData)
    //{
    //    abilityStats.abilityName = abilityData._abilityName;
    //    abilityStats.abilityPower = abilityData._abilityPower;
    //    abilityStats.abilityCost = abilityData._abilityCost;
    //    abilityStats.abilityRange = abilityData._abilityRange;
    //    abilityStats.abilityCooldown = abilityData._abilityCooldown;
    //}

    public void SetupAbilityIndicator(GameObject caster)
    {
        abilityIndicator.caster = caster;
    }

    public abstract void CastAbility();

    public void OnEnable()
    {
        //SetupAbilityStats(abilityConfigData);
    }
}






