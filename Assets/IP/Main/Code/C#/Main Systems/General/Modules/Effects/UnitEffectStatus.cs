using System;
using UnityEngine;
using AbilityInterface;
using System.Collections.Generic;
using System.Collections;
//using System.Linq;

public class UnitEffectStatus : MonoBehaviour
{    
    public IEnumerator IterateEffectPerSecond(IEffect effect)
    {
        for(int i = 0; i <= effect.EffectDuration; i++)
        {
            Debug.Log("Started Damage/Healing Over Time!");
            yield return new WaitForSeconds(1.0f);
            CalculateCurrentEffectDuration(effect);
        }
    }

    public IEnumerator IterateEffectPerPeriod(IEffect effect)
    {
            effect.ApplyEffect(gameObject);
            yield return new WaitForSeconds(effect.EffectDuration);
            effect.RemoveEffect(gameObject);
    }

    public void CalculateCurrentEffectDuration(IEffect effect)
    {
        if(effect.TemporaryDuration <= 0.1f)
        {
            effect.TemporaryDuration = 0;
            effect.RemoveEffect(gameObject);
        }
        else
        {
            effect.ApplyEffect(gameObject);
            effect.TemporaryDuration -= 1.0f;
        }

    }

    public void TriggerEffect(IEffect effect)
    {
        if(effect.MyType == EffectType.Overtime)
        {
            StartCoroutine(IterateEffectPerSecond(effect));
        }
        else
        {
            StartCoroutine(IterateEffectPerPeriod(effect));
        }
    }
    
}