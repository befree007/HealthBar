using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _value;
    [SerializeField] private float _speed;
    private float _healthBarValue;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBarValue = _healthBar.value;
    }

    private void Update()
    {
        if (_healthBar.value != _healthBarValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _healthBarValue, _speed * Time.deltaTime);
        }        
    }

    public void AddHealth()
    {
        _healthBarValue = _healthBar.value + _value;
    }

    public void RemoveHealth()
    {
        _healthBarValue = _healthBar.value - _value;
    }
}
