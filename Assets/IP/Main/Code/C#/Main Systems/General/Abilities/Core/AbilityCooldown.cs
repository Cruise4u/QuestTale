using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCooldown : MonoBehaviour
{
    public AbilityBBBook abilityBook;
    public List<float> cooldownList;
    //public List<bool> activeSkills;

    public Action<float> CooldownEvent;

    public void Start()
    {
        SetCooldownForEachAbility();
        ResetCooldowns();
    }

    public void SetCooldownForEachAbility()
    {
        foreach (AbilityPrototype ability in abilityBook.abilityList)
        {
            cooldownList.Add(ability.abilityStats.abilityCD);
            //activeSkills.Add(false);
        }
    }

    public float GetCooldown(int index)
    {
        return cooldownList[index];
    }

    //public void ProcessCooldown(int index, float cd)
    //{
    //    if(gameObject.CompareTag("enemy"))
    //    {
    //        if (cooldownList[index] >= 0.1f)
    //        {
    //            cooldownList[index] -= Time.deltaTime;
    //        }
    //        else
    //        {
    //            cooldownList[index] = 0.0f;
    //        }
    //    }
    //    else
    //    {
    //        if (cooldownList[index] >= 0.1f)
    //        {
    //            cooldownList[index] -= Time.deltaTime;
    //            userInterface.ConverNumberToText(userInterface.uiButtons[index], index, cooldownList[index]);
    //        }
    //        else
    //        {
    //            cooldownList[index] = 0.0f;
    //            userInterface.SetEmptyUI(index);
    //        }
    //    }
    //}

    //public float StartCooldown(int index, float cd)
    //{
    //    if (gameObject.CompareTag("enemy"))
    //    {
    //        cooldownList[index] = abilityBook.abilityList[index].abilityStats.abilityCD;
    //    }
    //    else
    //    {
    //        var mainImage = userInterface.uiButtons[index];
    //        var secondaryImage = userInterface.uiButtons[index].transform.GetChild(0).gameObject;
    //        userInterface.ChangeButtonColour(mainImage, Color.white);
    //        userInterface.ChangeButtonColour(secondaryImage, Color.gray);
    //        cooldownList[index] = abilityBook.abilityList[index].abilityStats.abilityCD;
    //    }
    //    return cooldownList[index];
    //}

    public void SetCooldownToMaximum(int index)
    {
        cooldownList[index] = abilityBook.abilityList[index].abilityStats.abilityCD;
    }

    public void ResetCooldowns()
    {
        for (int i = 0; i < cooldownList.ToArray().Length; i++)
        {
            cooldownList[i] = 0.0f;
        }
    }

}



