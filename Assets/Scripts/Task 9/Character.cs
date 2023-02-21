using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Character : MonoBehaviour
{
    [SerializeField] private float _value;
    private float _maxHealth;
    private float _minHealth;
    [HideInInspector] public float _currentHealth;

    private void Start()
    {
        _currentHealth = GetComponent<Slider>().value;
        _maxHealth = GetComponent<Slider>().maxValue;
        _minHealth = GetComponent<Slider>().minValue;
    }

    public void Health()
    {
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
        {
            _currentHealth += _value;
        }
    }

    public void Damage()
    {
        if (_currentHealth < _minHealth)
        {
            _currentHealth = _minHealth;
        }
        else
        {
            _currentHealth -= _value;
        }
    }
}
