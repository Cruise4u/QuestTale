using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public Ability defaultAbility;
    public AbilityIndicator defaultIndicator;

    public Dictionary<string, Ability> abilityDictionary;
    public CooldownController cooldownController;



    public void AssignDefaultAbilityAs(Ability ability)
    {
        defaultAbility = ability;
    }
}
