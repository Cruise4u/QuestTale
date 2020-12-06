using System;
using UnityEngine;
using InterfaceLibrary;
using AbilityInterface;
using System.Collections.Generic;
using Bolt;

namespace EffectsLibrary
{
    public class BlindingEffect : IEffect
    {
        public int damageBeforeBlinding { get; set; }
        public float EffectDuration { get ; set ; }
        public float TemporaryDuration { get; set; }
        public EffectType MyType { get; set; }
        

        public void ApplyEffect(GameObject target)
        {
            damageBeforeBlinding = target.GetComponent<UnitStatss>().attackPower;
            target.GetComponent<UnitStatss>().attackPower = 0;
            Debug.Log("Enemy cannot hit target! It's vision is blurred!");
        }

        public void RemoveEffect(GameObject target)
        {
            target.GetComponent<UnitStatss>().attackPower = damageBeforeBlinding;
        }
    }

    public class BurningEffect : IEffect
    {
        public int DotDamage { get; set; }
        public float EffectDuration { get; set; }
        public float TemporaryDuration { get; set; }
        public EffectType MyType { get; set; }

        public void ApplyEffect(GameObject target)
        {
            CustomEvent.Trigger(target,"TakeDamageEvent",DotDamage);
        }

        public void RemoveEffect(GameObject target)
        {
            //Do nothing   
        }
    }

}


