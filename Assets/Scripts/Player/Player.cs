using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Player : MonoBehaviour 
{
    [SerializeField] private Health _health;

    private Collider2D _collider;

    public event Action<Vector3> GetDamage;
    public event Action GetFirstAid;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryGetDamage(collision);
        TryPickupAid(collision);
    }

    private void TryGetDamage(Collider2D collision)
    {
        if (collision.TryGetComponent(out EnemyDamager enemy))
        {
            _health.LoseHealth(enemy.Damage);
            GetDamage?.Invoke(enemy.transform.position);
        }
    }

    private void TryPickupAid(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out FirstAid aid))
        {
            _health.RestoreHealth(aid.HealAmount);
            GetFirstAid?.Invoke();
        }
    }
}
