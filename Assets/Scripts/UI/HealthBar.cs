using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]

public class HealthBar : MonoBehaviour
{
    [field: SerializeField] public Slider Slider { get; private set; }
    
    public void SetMaxHealth(int health)
    {
        Slider.maxValue = health;
        SetHealth(health);
    }

    public void SetHealth (int health)
    {
        Slider.value = health;
    }

}
