using UnityEngine;
using InterfaceLibrary;
using AbilityInterface;

public enum ProjectileBehaviourType
{
    Damage,
    Heal,
    Utility,
}

public abstract class AbilityProjectile : MonoBehaviour
{
    public AbilityPrototype ability;

    public string colliderTag;
    public abstract void SelfDestructAterSeconds(float seconds, string poolName);
    public abstract void OnCollidingWithTarget(Collider collider, string tag);

}

