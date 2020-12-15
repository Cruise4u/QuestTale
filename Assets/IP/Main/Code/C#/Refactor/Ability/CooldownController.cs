using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Events;

public class CooldownController : ICooldownObservee
{
    public List<ICooldownObserver> _observerList;

    public List<ICooldownObserver> observerList { get => _observerList; set => observerList = value; }
    public Func<Ability, float> EventCooldown { get => GetAbilityCooldown; set => EventCooldown = value; }

    public float GetAbilityCooldown(Ability ability)
    {
        return ability.abilityStats.abilityCooldown;
    }

    public void SetAbilityCooldownToMaximum(Ability ability,AbilityData data)
    {
        ability.abilityStats.abilityCooldown = data._abilityCooldown;
    }

    public void ResetAbilitiesCooldownOnStart(Ability[] abilities)
    {
        foreach(Ability ability in abilities)
        {
            ability.abilityStats.abilityCooldown = 0;
        }
    }

    public void AttachObserver(ICooldownObserver observer)
    {
        observerList.Add(observer);
    }

    public void RemoveObserver(ICooldownObserver observer)
    {
        observerList.Remove(observer);
    }

    public void NotifyObserver(ICooldownObserver observer)
    {
        observer.UpdateCooldown();
    }

}
