using UnityEngine;
using System;
using System.Collections.Generic;

public class IndicatorController : MonoBehaviour
{
    public List<IndicatorPrototype> IndicatorList;
    public IndicatorPrototype defaultIndicator;
    public GameObject TemporaryIndicator;

    #region Indicator Methods

    // Turn On/Off the indicator if doesn't need to be replaced or if it was used and the ability is in cooldown..
    public void ToggleIndicator()
    {
        if (TemporaryIndicator.activeSelf == true)
        {
            TemporaryIndicator.SetActive(false);
        }
        else
        {
            TemporaryIndicator.SetActive(true);
        }
    }

    // Set a speciic indicador as default
    public void SetDefaultIndicator(int index)
    {
        defaultIndicator = IndicatorList[index];
    }

    // Set the indicator as a child of the GameObject which the script is attached to
    public void SetObjectAsChild()
    {
        defaultIndicator.SetIndicatorAsChild(TemporaryIndicator, gameObject);
    }

    // Creates an instance and spawns a visual representation of the indicator 
    public void SpawnIndicator(int index)
    {
        SetDefaultIndicator(index);
        TemporaryIndicator = Instantiate(IndicatorList[index].Prefab);
        TemporaryIndicator.name = "Indicator";
        TemporaryIndicator.transform.position = new Vector3(gameObject.transform.position.x, 1.0f, gameObject.transform.position.z);
        SetObjectAsChild();
        ToggleIndicator();
    }

    // Destroys any instance ( The only one ) with the name "Indicator" That is a child of the parent GameObject
    public void DestroyIndicatorInstance()
    {
        TemporaryIndicator = null;
        var refObject = GameObject.Find("Indicator");
        Destroy(refObject);
    }

    // Destroys the instance and instantiate a new indicator instance of a different or same type (switches one for another)
    public void SwitchIndicator(int index)
    {
        DestroyIndicatorInstance();
        SpawnIndicator(index);
    }

    #endregion
}

