using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthSystem
{
    public Slider healthSlider;
    void Start()
    {
        healthSlider.maxValue = maxHealth;
        UpdateSlider(Health);
    }

    public override void UpdateSlider(int health)
    {
        healthSlider.value = health;
    }
}
