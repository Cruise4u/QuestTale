using System;
using System.Collections.Generic;

public interface ICooldownObserver
{
    void UpdateCooldown();
}

public interface ICooldownObservee
{
    List<ICooldownObserver> observerList { get; set; }
    Func<Ability, float> EventCooldown { get; set; }

    void AttachObserver(ICooldownObserver observer);

    void RemoveObserver(ICooldownObserver observer);

    void NotifyObserver(ICooldownObserver observer);
}

