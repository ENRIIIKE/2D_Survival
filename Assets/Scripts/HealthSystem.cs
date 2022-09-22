using UnityEngine;

public abstract class HealthSystem : MonoBehaviour
{
    [Header("General")]
    private int health;

    public int Health
    {
        get { return health; }
        private set { health = value; }
    }

    public int maxHealth;

    public bool isDead;

    private void Awake()
    {
        Health = maxHealth;
    }
    public void GetDamage(int damage)
    {
        if (damage > Health)
        {
            Health = 0;
        }
        else
        {
            Health -= damage;
        }

        UpdateSlider(Health);
        CheckHealthState();
    }
    private void CheckHealthState()
    {
        if (Health <= 0)
        {
            isDead = true;

            PlayerController playerController;
            //EntityController entityController;

            try
            {
                playerController = GetComponent<PlayerController>();
                //entityController = GetComponent<EntityController>();

                playerController.enabled = false;
                //entityController.enabled = false;
            }
            catch
            {
                Debug.LogWarning("No controller found");
            }
        }
    }
    public abstract void UpdateSlider(int health);
}
