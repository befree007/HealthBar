using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _value;

    private Slider _startHealthBar;
    private float _maxHealth;
    private float _minHealth;    
    public event UnityAction HealthChanged;
    public float CurrentHealth { get; private set; }
    

    private void Start()
    {
        _startHealthBar = GetComponent<Slider>();
        CurrentHealth = _startHealthBar.value;
        _maxHealth = _startHealthBar.maxValue;
        _minHealth = _startHealthBar.minValue;
    }    

    public void Heal()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth + _value, _minHealth, _maxHealth);

        HealthChanged?.Invoke();
    }

    public void Damage()
    {
        CurrentHealth = Mathf.Clamp(CurrentHealth - _value, _minHealth, _maxHealth);

        HealthChanged?.Invoke();
    }
}
