using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Slider))]
public class SmoothHealthBar : HealthView
{
    [SerializeField] private float _speedChange = 10;

    private Slider _slider;
    private Coroutine _currentChangeing;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _slider.value = Player.CurrentHealth / Player.MaxHealth;
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        if (_currentChangeing != null)
        {
            StopCoroutine(_currentChangeing);
        }

        _currentChangeing = StartCoroutine(SmoothHealthChange(currentHealth, _slider.value));
    }

    private IEnumerator SmoothHealthChange(float currentHealth, float startValue)
    {
        float target = currentHealth / Player.MaxHealth;

        while (startValue != target)
        {
            float start = _slider.value;
            float time = Mathf.Clamp01(_speedChange * Time.deltaTime);
            _slider.value = Mathf.Lerp(start, target, time);

            yield return null;
        }
    }
}
