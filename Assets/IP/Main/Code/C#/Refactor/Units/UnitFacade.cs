using System;
using UnityEngine;

public class UnitFacade : MonoBehaviour
{
    public StatsData unitStatsData;
    public UnitStats myStats;
    public UnitMovementAndRotation unitMovement;
    public UnitActions unitActions;
    public UnitTarget unitTarget;

    public void SetupUnit()
    {
        SetStatsValues();
        unitMovement = new UnitMovementAndRotation();
        unitActions = new UnitActions();
    }

    public void SetStatsValues()
    {
        myStats.CurrentHealth = unitStatsData._currentHealth;
        myStats.MaxHealth = unitStatsData._maxHealth;
        myStats.CurrentMana = unitStatsData._currentMana;
        myStats.MaxMana = unitStatsData._maxMana;
        myStats.AttackRange = unitStatsData._attackRange;
        myStats.AttackPower = unitStatsData._attackPower;
        myStats.AttackSpeed = unitStatsData._attackSpeed;
        myStats.MovementSpeed = unitStatsData._movementSpeed;
    }


}

public struct UnitStats
{
    public int CurrentHealth;
    public int MaxHealth;
    public int CurrentMana;
    public int MaxMana;
    public int AttackPower;
    public float AttackSpeed;
    public float AttackRange;
    public float AttackCooldown;
    public int MovementSpeed;
}
