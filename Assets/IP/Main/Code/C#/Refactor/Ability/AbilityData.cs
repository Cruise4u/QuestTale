using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Stats",order = 0)]
public class AbilityData : ScriptableObject
{
    public string _abilityName;
    public int _abilityPower;
    public int _abilityRange;
    public int _abilityCost;
    public float _abilityCooldown;
}
