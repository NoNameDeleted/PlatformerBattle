using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;

    public event Action GetFirstAid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out FirstAid aid))
        {
            _health.RestoreHealth(aid.HealAmount);
            GetFirstAid?.Invoke();
        }
    }
}
