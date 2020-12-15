using System;
using UnityEngine;
using DG.Tweening;
using System.Collections;
using TMPro;

public class UICombatTextHandler : MonoBehaviour
{
    GameObject textObject;
    UICombatTextTransform uiTextTransformer;
    UICombatText uiText;

    Vector3 initialPosition;

    public void Start()
    {
        uiTextTransformer = new UICombatTextTransform();
        uiText = new UICombatText();
        uiTextTransformer.floatingOffset = 1;
        uiTextTransformer.floatingSpeed = 1.5f * Time.deltaTime;
        initialPosition = textObject.transform.position;
    }

    public void DisplayText(string text)
    {
        if(textObject.activeSelf != true)
        {
            textObject.SetActive(true);
        }
        uiText.SetText(textObject, text);
        uiTextTransformer.FloatingText(textObject, uiTextTransformer.floatingSpeed, uiTextTransformer.floatingOffset);
        StartCoroutine(DestroyTextAfterSeconds(textObject, uiTextTransformer, 1.1f));
    }

    public void ResetText()
    {
        uiText.ClearText(textObject);
        uiTextTransformer.ResetTextPosition(textObject,initialPosition);
    }   

    public IEnumerator DestroyTextAfterSeconds(GameObject obj, UICombatTextTransform textTransformer, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
        uiText.ClearText(obj);
        uiTextTransformer.ResetTextPosition(obj, initialPosition);
    }
}

public class UICombatTextTransform
{
    public float floatingSpeed;
    public float floatingOffset;

    public void FloatingText(GameObject textObject, float speed, float offset)
    {
        var textUpwardPosition = new Vector3(0, offset, 0);
        textObject.transform.DOMove(textUpwardPosition, 1.0f);
    }

    public void ResetTextPosition(GameObject textObject,Vector3 resetPosition)
    {
        textObject.transform.position = resetPosition;
    }
}

public class UICombatText
{
    public void SetText(GameObject obj,string text)
    {
        obj.GetComponent<TextMeshPro>().text = text;
    }

    public void ClearText(GameObject obj)
    {
        obj.GetComponent<TextMeshPro>().text = "";
    }

    public string ConvertDamageToText(int damage)
    {
        string message = "";
        if (damage >= 1)
        {
            message = damage.ToString();
        }
        else
        {
            message = "Miss";
        }
        return message;
    }

}
