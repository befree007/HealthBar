using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private UnityEvent _healthChanged;
    private Slider _healthBar;
    private float _maxHealth;
    private float _minHealth;    
    [HideInInspector] public float CurrentHealth { get; private set; }

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        CurrentHealth = _healthBar.value;
        _maxHealth = _healthBar.maxValue;
        _minHealth = _healthBar.minValue;
    }

    public void Heal()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _value, _minHealth, _maxHealth);

        _healthChanged.Invoke();
    }

    public void Damage()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _value, _minHealth, _maxHealth);

        _healthChanged.Invoke();
    }
}
