using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector]
    public GameObject shooter;
    [HideInInspector] 
    public int damage;

    public float destroyCooldown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamagable>() != null && collision.gameObject != shooter)
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            damagable.GetDamage(damage, shooter);

            Vector2 lastPosition = transform.position;

            Debug.DrawLine(shooter.transform.position, lastPosition, 
                Color.yellow, destroyCooldown);

            Destroy(gameObject);

        }
        if (!collision.CompareTag("Ignore") || collision.gameObject == shooter)
        {
            Debug.Log("Projectile collided with <color=orange>" + collision.name + " </color>"
                , collision.gameObject);

            Destroy(gameObject);
        }


    }
    private void Start()
    {
        Destroy(gameObject, destroyCooldown);


    }
}
