//using UnityEngine;
//using System;

//[CreateAssetMenu(menuName = "AI Skills/Frenzy", order = 0)]
//public class Frenzy : AbilityPrototype
//{
//    public override void CastAbility(GameObject caster, int behaviour)
//    {
//        switch (behaviour)
//        {
//            case 0:
//                IncreasePower(caster);
//                break;
//        }
//    }

//    public void IncreasePower(GameObject caster)
//    {
//        caster.GetComponent<UnitStats>().attackPower += abilityStats.abilityPower;
//    }

//    public override void SetIndicatorController(GameObject caster)
//    {

//    }


//}