using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _speed;
    private Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    public void StartChangeHealth()
    {
        StartCoroutine(ChangeHealth());
    }

    private IEnumerator ChangeHealth()
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
