using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private HealthBar _healthBar;
    private Slider _startHealthBar;
    private float _maxHealth;
    private float _minHealth;    
    public UnityAction onHealthChanged;
    [HideInInspector] public float CurrentHealth { get; private set; }
    

    private void Start()
    {
        _startHealthBar = GetComponent<Slider>();
        CurrentHealth = _startHealthBar.value;
        _maxHealth = _startHealthBar.maxValue;
        _minHealth = _startHealthBar.minValue;
    }

    private void OnEnable()
    {
        onHealthChanged += _healthBar.StartChangeHealth;
    }

    private void OnDisable()
    {
        onHealthChanged -= _healthBar.StartChangeHealth;
    }

    public void Heal()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _value, _minHealth, _maxHealth);

        onHealthChanged?.Invoke();
    }

    public void Damage()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _value, _minHealth, _maxHealth);

        onHealthChanged?.Invoke();
    }
}
