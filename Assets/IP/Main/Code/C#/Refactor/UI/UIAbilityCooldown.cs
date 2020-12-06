using System;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilityButton
{
    public void ConverNumberToText(GameObject obj, GameObject button, float cooldown)
    {
        var image = obj.transform.GetChild(0).GetComponent<Image>().fillAmount = (1 / cooldown);
        var convertedNumber = (int)cooldown;
        button.transform.GetChild(1).GetComponent<Text>().text = convertedNumber.ToString();
    }

    public void SetEmptyUI(GameObject button)
    {
        button.transform.GetChild(0).GetComponent<Image>().fillAmount = 0;
        button.transform.GetChild(1).GetComponent<Text>().text = " ";
    }
}
