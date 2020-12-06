using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Spell Book")]
public class AbilityBBBook : ScriptableObject
{
    public List<AbilityPrototype> abilityList;
}
