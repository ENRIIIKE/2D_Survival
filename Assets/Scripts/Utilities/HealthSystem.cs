using UnityEngine;

public abstract class HealthSystem : MonoBehaviour, IDamagable
{
    [Header("General")]
    public int health;

    public int maxHealth;

    public bool isDead;

    private void Awake()
    {
        health = maxHealth;
    }
    public void GetDamage(int damage)
    {
        if (damage > health)
        {
            health = 0;
        }
        else
        {
            health -= damage;

            /*
            Debug.LogFormat("<color=white><b>Damage Debug</b> </color> " +
                "\n{0} " +
                "\nDamage Taken: {1} " +
                "\nRemaining Health: {2} "
                , gameObject.name, damage, health);
            */
        }
        CheckHealthState();
    }
    private void CheckHealthState()
    {
        if (health > 0) return;
        isDead = true;

        Destroy(gameObject, 0.12f);
    }
}
