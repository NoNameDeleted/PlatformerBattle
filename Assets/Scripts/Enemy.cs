using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public event Action GetDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Damager>(out Damager damageArea))
        {
            GetDamage?.Invoke();
        }
    }
}
