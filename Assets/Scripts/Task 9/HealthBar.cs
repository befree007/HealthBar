using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Character _character;
    [SerializeField] private float _speed;
    [HideInInspector] public Slider healthBar;

    private void Start()
    {
        healthBar = GetComponent<Slider>();
    }

    private void Update()
    {
        ChangeHealth();
    }

    public void ChangeHealth()
    {
        if (healthBar.value != _character._healthBarValue)
        {
            healthBar.value = Mathf.MoveTowards(healthBar.value, _character._healthBarValue, _speed * Time.deltaTime);
        }
    }
}
