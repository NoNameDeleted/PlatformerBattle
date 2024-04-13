using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour 
{
    [SerializeField] private Collider2D _collider;

    public event Action<Vector3> GetDamage;
    public event Action GetFirstAid;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryGetDamage(collision);
        TryPickupAid(collision);
    }

    private void TryGetDamage(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Damager>(out Damager damageArea) && 
            collision.GetComponentInParent<Enemy>())
        {
            GetDamage?.Invoke(damageArea.transform.position);
        }
    }

    private void TryPickupAid(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<FirstAid>(out FirstAid aidArea))
        {
            GetFirstAid?.Invoke();
        }
    }
}
