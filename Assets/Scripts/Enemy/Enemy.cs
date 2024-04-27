using System;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    [SerializeField] private Health _health;

    public event Action GetDamage;

    public void TakeDamage(int damage)
    {
        _health.LoseHealth(damage);
        GetDamage?.Invoke();
    }
}
