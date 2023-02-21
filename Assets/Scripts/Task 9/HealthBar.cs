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
        while (true)
        {
            if (healthBar.value != _character._currentHealth)
            {
                healthBar.value = Mathf.MoveTowards(healthBar.value, _character._currentHealth, _speed * Time.deltaTime);
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
