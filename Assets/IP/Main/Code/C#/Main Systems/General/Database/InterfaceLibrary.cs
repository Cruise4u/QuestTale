using AbilityInterface;
using System;
using UnityEngine;
using UnityEngine.AI;

namespace InterfaceLibrary
{
    public enum DamageType
    {
        Basic,
        Ability
    }

    public interface IDamager
    {
        void DealDamage(IDamagable damagable);
    }

    public interface IDamagable
    {
        void TakeDamage(int damage,DamageType type);
    }

    public interface IMove
    {
        void Move(IMovable movable, int behaviour);
    }

    public interface IMovable
    {
        void MoveToDestination(Vector3 destination);
        void StopMoving();
        void SetStoppingDistance(float distance);
    }

    public interface IProjectile
    {
        void OnCollidingWithTarget(Collider collider, string colliderTag);
        void DestroyProjectileAfterSeconds(float seconds, string poolName);
    }

    public interface IMarker
    {
        void MarkTarget(IMarkable markable);
        void RemoveMark(IMarkable markable);
    }

    public interface IMarkable
    {
        bool IsMarked { get; set; }
        Collider GetCollider { get; }
        void Marked();
        void Unmarked();
    }

    public interface IStunnable
    {
        bool IsStunned { get; set; }
        void Stunned(float duration);
        void Unstunned();
    }

    public interface ICameraRay
    {
        Ray GetRayFromCameraToPosition(Vector3 position);
    }

    public interface IText
    {
        void Write(string text);
    }

    public interface ITexter
    {
        string SetMessage(IText text);
    }



}
