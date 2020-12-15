using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class UnitUI : MonoBehaviour
{
    public UICombatTextHandler combatTextHandler;
    public UIBarsHandler barsHandler;

    public void Notify(IMediated mediated)
    {
        mediated.Notify();
    }


}

public class PlayerUnitUI : UnitUI
{
    //UIButtons if necessary
    //UIEffects(Poison,Fire,etc.)
}

public interface IMediator
{
    void Mediate(IMediated mediated);
}

public interface IMediated
{
    void Notify();
}