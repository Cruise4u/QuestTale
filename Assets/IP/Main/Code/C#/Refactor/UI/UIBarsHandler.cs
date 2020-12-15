using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarsHandler : MonoBehaviour
{
    public List<Image> barList;

    public void UpdateBarsSlider(UnitStats stats)
    {
        if (barList != null && barList.Count > 1)
        {
            barList[0].fillAmount = stats.CurrentHealth / (float)stats.MaxHealth;
            barList[1].fillAmount = stats.CurrentMana / (float)stats.MaxMana;
        }
        else
        {
            barList[0].fillAmount = stats.CurrentHealth / (float)stats.MaxHealth;
        }
    }

    public void UpdateUIEffects()
    {
        //Todo
    }
}

