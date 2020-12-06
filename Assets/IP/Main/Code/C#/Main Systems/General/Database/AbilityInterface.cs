using InterfaceLibrary;
using System;
using UnityEngine;

namespace AbilityInterface
{
    public interface IAbilityLauncher
    {
        void LaunchAbility(GameObject launcher);
    }

    public interface IAreaEffect
    {
        void AffectArea(GameObject areaIndicator, float radius);
    }

    public interface IEffect
    {
        EffectType MyType { get; set; }
        float EffectDuration { get; set; }
        float TemporaryDuration { get; set; }
        void ApplyEffect(GameObject target);
        void RemoveEffect(GameObject target);
    }

    public enum EffectType
    {
        Buff,
        Overtime,
    }

    public interface IAbilityWarning
    {
        void DisplayDangerZone(GameObject caster, float elapsedTime);
        void ToggleWarning(GameObject caster);
        void RestartWarning(GameObject caster);
    }

    public interface IStun
    {
        void Stun(IStunnable stunable,float duration);
        float ReferenceStunDuration();
    }

}
