using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
    public event Action GetDamage;

    public void TakeDamage()
    {
        GetDamage?.Invoke();
    }
}
