using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _speed;
    [HideInInspector] public Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
        StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
    {
        if (healthBar.value != _character.CurrentHealth)
        {
            healthBar.value = Mathf.MoveTowards(healthBar.value, _character.CurrentHealth, _speed * Time.deltaTime);
        }

        yield return new WaitUntil(() => healthBar.value != _character.CurrentHealth);

        yield return StartCoroutine(ChangeHealth());
    }
}
