using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBars
{
    List<GameObject> barList;

    public void SetupBars(UIBarsData uiBar)
    {
        barList = uiBar.barList;
    }

    public void UpdateBarsSlider(UnitStats stats)
    {
        if (barList != null && barList.Count > 1)
        {
            barList[0].GetComponent<Image>().fillAmount = stats.CurrentHealth / (float)stats.MaxHealth;
            barList[1].GetComponent<Image>().fillAmount = stats.CurrentMana / (float)stats.MaxMana;
        }
        else
        {
            barList[0].GetComponent<Image>().fillAmount = stats.CurrentHealth / (float)stats.MaxHealth;
        }
    }

    public void UpdateUIEffects()
    {
        //Todo
    }
}
