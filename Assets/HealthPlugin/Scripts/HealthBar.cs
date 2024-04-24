using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : HealthView
{
    private Slider _slider;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = Player.CurrentHealth / Player.MaxHealth;
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        _slider.value = currentHealth / Player.MaxHealth;
    }
}
