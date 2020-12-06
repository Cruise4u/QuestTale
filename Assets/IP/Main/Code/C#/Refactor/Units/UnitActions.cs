using System;
using UnityEngine;

public class UnitActions
{



}

public interface IDamager
{
    void DealDamage(IDamagable damagable);
}

public interface IDamagable
{
    void TakeDamage(int damage);
}

public interface IInteractor
{
    void InteractWith(IInteractable interactable);
}

public interface IInteractable
{
    void Interact();
}