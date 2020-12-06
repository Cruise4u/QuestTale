using UnityEngine;

[CreateAssetMenu(menuName = "Units/Data", order = 0)]
public class StatsData : ScriptableObject
{
    public int _currentHealth;
    public int _maxHealth;
    public int _currentMana;
    public int _maxMana;
    public int _movementSpeed;
    public int _attackPower;
    public float _attackRange;
    public float _attackSpeed;
}