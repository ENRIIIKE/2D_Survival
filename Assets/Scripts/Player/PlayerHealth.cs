using UnityEngine.UI;

public class PlayerHealth : HealthSystem
{
    public Slider healthSlider;
    void Start()
    {
        healthSlider.maxValue = maxHealth;
    }

    private void Update()
    {
        healthSlider.value = health;
    }
}
