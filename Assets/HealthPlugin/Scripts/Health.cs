using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _healthPoint = 50;
    [SerializeField] private int _maxHealth = 100;

    public event Action<float> Changed;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _healthPoint;

    public bool LoseHealth(int damageAmount = 1)
    {
        if (_healthPoint > 0)
        {
            _healthPoint -= Mathf.Clamp(damageAmount, 0, _healthPoint);
            Changed?.Invoke(_healthPoint);
        }

        return _healthPoint > 0;
    }

    public bool RestoreHealth(int healAmount = 1)
    {
        if (_healthPoint < _maxHealth)
        {
            _healthPoint += Mathf.Clamp(healAmount, 0, _maxHealth - _healthPoint);
            Changed?.Invoke(_healthPoint);
        }

        return _healthPoint < _maxHealth;
    }
}
