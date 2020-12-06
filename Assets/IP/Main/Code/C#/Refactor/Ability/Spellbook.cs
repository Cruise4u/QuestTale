using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SpellBook
{
    public Dictionary<string, AbilityTemplate> abilityDictionary;
    public Dictionary<string, AbilityData> abilityDataDictionary;

    public void SetAbilityStats()
    {
        foreach (KeyValuePair<string, AbilityTemplate> kvp in abilityDictionary)
        {
            var key = kvp.Key;
            if (abilityDictionary.ContainsKey(key))
            {
                abilityDictionary[key].abilityStatistics.AbilityPower = abilityDataDictionary[key]._abilityPower;
                abilityDictionary[key].abilityStatistics.AbilityRange = abilityDataDictionary[key]._abilityRange;
                abilityDictionary[key].abilityStatistics.AbilityCost = abilityDataDictionary[key]._abilityCost;
                abilityDictionary[key].abilityStatistics.AbilityCooldown = abilityDataDictionary[key]._abilityCooldown;
            }
        }
    }

    public void GetAbilityByName(string abilityName)
    {

    }
}
