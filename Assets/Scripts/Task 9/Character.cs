using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _value;
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
        if (CurrentHealth > _maxHealth)
        {
            CurrentHealth = _maxHealth;
        }
        else
        {
            CurrentHealth += _value;
        }
    }

    public void Damage()
    {
        if (CurrentHealth < _minHealth)
        {
            CurrentHealth = _minHealth;
        }
        else
        {
            CurrentHealth -= _value;
        }
    }
}
