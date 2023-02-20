using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private HealthBar _health;
    [SerializeField] private float _value;    
    [HideInInspector] public float _healthBarValue;

    private void Start()
    {
        _healthBarValue = _health.healthBar.value;
    }

    public void AddHealth()
    {
        _healthBarValue += _value;
    }

    public void RemoveHealth()
    {
        _healthBarValue -= _value;
    }
}
