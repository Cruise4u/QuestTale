using UnityEngine;
using Bolt;
using System;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Unit Container", menuName = "Units/Unit Stats", order = 0)]
public class UnitSO : ScriptableObject
{
    public string UnitName;
    public string _Name { get { return UnitName; } }

    public int AttackPower;
    public int _AttackPower { get {return AttackPower; } }

    public int CurrentHealth;
    public int _CurrentHealth { get { return CurrentHealth; } }

    public int MaxHealth;
    public int _MaxHealth { get { return MaxHealth; } }

    public int CurrentEnergy;
    public int _CurrentEnergy { get { return CurrentEnergy; } }

    public int MaxEnergy;
    public int _MaxEnergy { get { return MaxEnergy; } }

    public float AttackSpeed;
    public float _AttackSpeed { get { return AttackSpeed; } }

    public float AttackCD;
    public float _AttackCD { get { return AttackCD; } }

    public float AttackRange;
    public float _AttackRange { get { return AttackRange; } }

    public float MovementSpeed;
    public float _MovementSpeed { get { return MovementSpeed; } }

    public float SightRange;
    public float _SightRange { get { return SightRange; } }

}
