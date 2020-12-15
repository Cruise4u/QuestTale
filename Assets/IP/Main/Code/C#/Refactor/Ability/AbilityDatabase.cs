using System;
using System.Collections.Generic;
using UnityEngine;

public static class AbilityDatabase
{
    public static List<Ability> abilityList;
    public static Dictionary<string, Ability> abilityBook;

    public static void CreateDictionary()
    {
        abilityBook = new Dictionary<string, Ability>();
    }

    public static void SetAbilityDictionary()
    {
        foreach(Ability ability in abilityList)
        {
            abilityBook.Add(ability.abilityName, ability);
        }
    }

    public static void SetAbilityDataForAll(List<AbilityData> abilityConfigDataList)
    {
        for (int i = 0; i < abilityConfigDataList.Count; i++)
        {
            if (abilityBook[abilityConfigDataList[i]._abilityName] == abilityList[i])
            {
                abilityList[i].abilityConfigData = abilityConfigDataList[i];
            }
        }
    }


}
