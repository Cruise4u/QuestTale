using UnityEngine;

[CreateAssetMenu(menuName = "Ability Statistics")]
public class AbilityStats : ScriptableObject
{
    public string abilityName;
    public int abilityPower;
    public float abilityCD;
    public float abilityRange;
}
