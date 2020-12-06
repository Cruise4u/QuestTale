using System;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController
{
    public AbilityPrototype defaultAbility;
    public AbilityBBBook abilityBook;

    public void GetAbility(int index)
    {
        defaultAbility = abilityBook.abilityList[index];
    }

}
