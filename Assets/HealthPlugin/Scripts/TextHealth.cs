using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextHealth : HealthView
{
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProUGUI.text = Player.CurrentHealth.ToString() + "/" + Player.MaxHealth.ToString();
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        _textMeshProUGUI.text = currentHealth.ToString() + "/" + Player.MaxHealth.ToString();
    }
}
