using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour 
{
    [SerializeField] private Health _health;

    public event Action<Vector3> GetDamage;

    public void TakeDamage(int damage, Vector2 damagePoint)
    {
        _health.LoseHealth(damage);
        GetDamage?.Invoke(damagePoint);
    }
}
