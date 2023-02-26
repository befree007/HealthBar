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
    private Slider healthBar;
    private Coroutine changeHealth;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _character.onHealthChanged += StartChangeHealth;
    }

    private void OnDisable()
    {
        _character.onHealthChanged -= StartChangeHealth;
    }

    public void StartChangeHealth()
    {
        if (changeHealth != null)
        {
            StopCoroutine(changeHealth);
        }

        changeHealth = StartCoroutine(ChangeHealth());
    }

    public IEnumerator ChangeHealth()
    {
        while (healthBar.value != _character.CurrentHealth)
        {
            if (healthBar.value != _character.CurrentHealth)
            {
                healthBar.value = Mathf.MoveTowards(healthBar.value, _character.CurrentHealth, _speed * Time.deltaTime);
            }

            yield return null;
        }
    }
}
