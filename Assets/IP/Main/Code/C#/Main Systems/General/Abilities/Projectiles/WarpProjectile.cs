using InterfaceLibrary;
using System;
using UnityEngine;

public class WarpProjectile : AbilityProjectile, IDamager,IMarkable
{
    public string teleportableTag;
    public bool IsMarked { get; set; }

    public Collider GetCollider { get { return gameObject.GetComponent<Collider>(); } }

    public void Update()
    {
        if(gameObject.activeSelf != false)
        {
            SelfDestructAterSeconds(7.0f, "BladePool");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        OnCollidingWithTarget(other, colliderTag);
    }

    public override void SelfDestructAterSeconds(float seconds, string poolName)
    {
        var pool = FindObjectOfType<ObjectPoolSystem>();
        var coroutine = pool.ReturnToPoolAfterSeconds(seconds, gameObject, poolName);
        StartCoroutine(coroutine);
    }

    public override void OnCollidingWithTarget(Collider collider, string tag)
    {
        if(gameObject.tag != teleportableTag)
        {
            if (collider.gameObject.CompareTag(colliderTag))
            {
                var damagable = collider.GetComponent<IDamagable>();
                var markable = collider.GetComponent<IMarkable>();
                DealDamage(damagable);
                MarkTarget(markable);
                Debug.Log("It's marked and damaged!");
                SelfDestructAterSeconds(0.1f, "BladePool");
            }
        }
    }

    public void DealDamage(IDamagable damagable)
    {
        var abilityDamage = ability.abilityStats.abilityPower;
        damagable.TakeDamage(abilityDamage);
    }

    public void MarkTarget(IMarkable markable)
    {
        markable.Marked();
    }

    public void RemoveMark(IMarkable markable)
    {
        markable.Marked();
    }

    public void Marked()
    {
        IsMarked = true;
    }

    public void Unmarked()
    {
        IsMarked = true;
    }
}
