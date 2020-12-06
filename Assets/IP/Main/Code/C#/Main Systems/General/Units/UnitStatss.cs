using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using System;
using Bolt;
using InterfaceLibrary;
using AbilityInterface;

public class UnitStatss : MonoBehaviour,IMovable,IDamagable,IStunnable
{
    public NavMeshAgent agent;
    public GameObject unitTarget;

    #region  Status

    public bool isAlive;
    public bool isInRangeToAttack;

    public bool IsStunned { get => isStunned; set => isStunned = value; }
    public bool isStunned;
    public float stunTimer;

    public bool isEvading;
    public bool IsEvading { get => isEvading; set => isEvading = value; }

    
    #endregion

    #region Stats
    
    public string unitName;
    public int currentHealth;
    public int maxHealth;
    public int attackPower;
    public float attackSpeed;
    public float attackCooldown;
    public float attackRange;
    public float movementSpeed;
    public float sightRange;

    #endregion

    //public void SetupStats()
    //{
    //    isStunned = false;
    //    isAlive = true;
    //    attackPower = statsContainer._AttackPower;
    //    currentHealth = statsContainer._CurrentHealth;
    //    maxHealth = statsContainer._MaxHealth;
    //    attackSpeed = statsContainer._AttackSpeed;
    //    attackCooldown = 0;
    //    attackRange = statsContainer._AttackRange;
    //    movementSpeed = statsContainer._MovementSpeed;
    //    sightRange = statsContainer._SightRange;
    //}

    public void SetCurrentHealth(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 1)
        {
            isAlive = false;
            currentHealth = 0;
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
    }

    public int GetHealthPercentage(float current, float max)
    {
        var percentage = (current / max) * 100;
        return Mathf.Clamp((int)percentage, 0, 100);
    }

    public float GetHealthThreshold()
    {
        float threshold = (currentHealth / maxHealth);
        var finalValue = Mathf.Clamp(threshold, 0.1f, 1);
        return finalValue;
    }

    public void TakeDamage(int damage,DamageType type)
    {
            CustomEvent.Trigger(gameObject, "TakeDamageEvent", damage);
    }

    public void UpdateBasicAttackCD()
    {
        if(attackCooldown >= 0.1f)
        {
            attackCooldown -= Time.deltaTime;
        }
        else
        {
            attackCooldown = 0;
        }
    }

    public void MoveToDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void StopMoving()
    {
        agent.isStopped = true;
        agent.ResetPath();
    }
    
    public void SetStoppingDistance(float distance)
    {
        agent.stoppingDistance = distance;
    }

    public void Stunned(float duration)
    {
        isStunned = true;
        CustomEvent.Trigger(gameObject, "StunEvent", duration);
        Debug.Log("I am stunned!");
    }

    public void Unstunned()
    {
        isStunned = false;
        CustomEvent.Trigger(gameObject, "UnstunEvent", isStunned);
        Debug.Log("I am NOT stunned!");
    }

    public void TakeDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
