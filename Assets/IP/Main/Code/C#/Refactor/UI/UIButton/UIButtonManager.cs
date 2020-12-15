using System;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonManager : MonoBehaviour
{
    List<UIButton> buttonList;

    public void Start()
    {
        buttonList = new List<UIButton>();
        GetAllUIButtons();
        //SortListByAscendingID();
    }

    public void GetAllUIButtons()
    {
        var UIButtons = FindObjectsOfType<UIButton>();
        foreach(UIButton button in UIButtons)
        {
            buttonList.Add(button);
        }
    }

    //public void SortListByAscendingID()
    //{
    //    var tempButton = new UIButton();
    //    Dictionary<int, int> indexDictionary = new Dictionary<int, int>();
    //    for (int i = 1; i < buttonList.Count; i++)
    //    {
    //        if (buttonList[i].buttonID != i)
    //        {
    //            indexDictionary.Add(buttonList[i].buttonID, i);
    //        }
    //    }
    //    for (int i = 1; i < buttonList.Count; i++)
    //    {
    //        if(buttonList[i].buttonID != i)
    //        {
    //            buttonList[i].buttonID = indexDictionary[i];
    //            Debug.Log(buttonList[i].buttonID);
    //        }
    //    }
    //}

    public UIButton GetUIButtonByID(int buttonID)
    {
        return buttonList[buttonID];
    }

}

