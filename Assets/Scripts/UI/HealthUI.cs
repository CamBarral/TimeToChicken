using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Text _health_txt;

    void Start()
    {

    }

    void Update()
    {

    }

    public void UpdateHealth(int health)
    {
        _health_txt.text = health.ToString();
    }
    
}
