using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private float _value;    
    [HideInInspector] public float _healthBarValue;

    private void Start()
    {
        _healthBarValue = GetComponent<Slider>().value;
    }

    public void Health()
    {
        _healthBarValue += _value;
    }

    public void Damage()
    {
        _healthBarValue -= _value;
    }
}
