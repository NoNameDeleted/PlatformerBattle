using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private int _healthPoint = 5;

    private void OnEnable()
    {
        _player.GetDamage += LoseHealth;
        _player.GetFirstAid += RestoreHealth;
    }

    private void OnDisable()
    {
        _player.GetDamage -= LoseHealth;
        _player.GetFirstAid -= RestoreHealth;
    }

    private void LoseHealth(Vector3 hitPosition)
    {
        if (_healthPoint > 0)
            _healthPoint--;
    }

    private void RestoreHealth()
    {
        _healthPoint++;
    }
}
