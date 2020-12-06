using UnityEngine;
using UnityEditor;
using DG.Tweening;

public abstract class AbilityPrototype : ScriptableObject
{
    public AbilityStats abilityStats;
    public abstract void CastAbility(GameObject caster,int behaviour);

    public abstract void SetIndicatorController(GameObject caster);
}
