using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _speed;
    private Slider _healthBar;
    private Coroutine _changeHealth;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _character.HealthChanged += StartChangeHealth;
    }

    private void OnDisable()
    {
        _character.HealthChanged -= StartChangeHealth;
    }

    private void StartChangeHealth()
    {
        if (_changeHealth != null)
        {
            StopCoroutine(_changeHealth);
        }

        _changeHealth = StartCoroutine(ChangeHealth());
    }

    public IEnumerator ChangeHealth()
    {
        while (_healthBar.value != _character.CurrentHealth)
        {
            if (_healthBar.value != _character.CurrentHealth)
            {
                _healthBar.value = Mathf.MoveTowards(_healthBar.value, _character.CurrentHealth, _speed * Time.deltaTime);
            }

            yield return null;
        }
    }
}
