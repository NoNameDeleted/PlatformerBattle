using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;

    protected Health Player => _health;

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    protected abstract void OnHealthChanged(float currentHealth);
}
