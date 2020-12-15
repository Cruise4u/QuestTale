using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour,ICooldownObserver
{
    public int buttonID;
    public float buttonCooldown;
    Action _CooldownTrigger;

    TextMeshPro textMeshPro;
    public Image[] icons;

    public Action MediatedAction { get => _CooldownTrigger.Invoke; set => MediatedAction = value; }

    public void Start()
    {
        icons = new Image[2];
        icons[0] = GetComponent<Image>();
        icons[1] = transform.GetChild(0).GetComponent<Image>();
        textMeshPro = transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
    }

    public void UpdateCooldown()
    {
        ReduceCooldown(Time.deltaTime);
        UpdateCooldownRadialFiller(0, buttonCooldown);
        PrintCooldownNumericValue(buttonCooldown);
    }

    public void ReduceCooldown(float amount)
    {
        buttonCooldown -= amount;
    }

    public void PrintCooldownNumericValue(float amount)
    {
        var convertedNumber = (int)amount;
        textMeshPro.text = convertedNumber.ToString();
    }

    public void UpdateCooldownRadialFiller(int index, float amount)
    {
        icons[index].fillAmount = (1 / amount);
    }

    public void EmptyCooldownNumericValue()
    {
        textMeshPro.text = " ";
    }

    public void ClearCooldownRadialFiller(int index)
    {
        icons[index].fillAmount = 1;
    }


}
