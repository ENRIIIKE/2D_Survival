using UnityEngine;

public abstract class HealthSystem : MonoBehaviour, IDamagable
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
    public void GetDamage(int damage, GameObject attacker)
    {
        if (damage > Health)
        {
            Health = 0;
        }
        else
        {
            Health -= damage;
        }


        Debug.LogFormat("<color=white><b>Damage Debug</b> </color> " +
            "\n " +
            "\n{0} Damage Taken: {1} " +
            "\nRemaining Health: {2} " +
            "\nAttacker: {3}" 
            , gameObject.name, damage, Health, attacker.name);

        UpdateSlider(Health);
        CheckHealthState();
    }
    private void CheckHealthState()
    {
        if (Health <= 0)
        {
            isDead = true;

            Destroy(gameObject, 0.12f);
        }
    }
    public abstract void UpdateSlider(int health);
}
