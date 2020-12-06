using UnityEngine;
using System.Collections;

public enum ProjectileEffect
{
    Teleport,
    Spread,
    Bounce,
}

namespace BoltInterface
{
    public interface IEffectable
    {
        void ApplyEffect(GameObject go);
        void RemoveEffect(GameObject go);
    }

    public interface ITeleportable
    {
        void TeleportToTarget(GameObject target);
    }

    public interface IGetUnits
    {
        void GetClosestAlly(GameObject go);
    }
    
    public interface IDestroyableAmmo
    {
        void DestroySelfAfterSeconds(float time, GameObject ammo, string poolName);
    }

    public interface ISpawnParticles
    {
        void TriggerParticles();
    }

}
