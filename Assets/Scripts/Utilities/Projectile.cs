using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Transform shooter;
    public Vector2 startPosition;

    [HideInInspector] 
    public int damage;

    public float destroyCooldown;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<IDamagable>() != null)
        {
            if (IgnorePlayer(collision)) return;

            IDamagable damagable = collision.GetComponent<IDamagable>();
            damagable.GetDamage(damage);

            Vector2 lastPosition = transform.position;

            Debug.DrawLine(startPosition, lastPosition, 
                Color.yellow, destroyCooldown);

        }

        if (!collision.CompareTag("Ignore"))
        {
            Destroy(gameObject);
        }
    }

    private bool IgnorePlayer(Collider2D collision)
    {
        if (collision.tag == shooter.tag)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnEnable()
    {
        transform.parent = GameObject.Find("--Temporary--").transform;
        startPosition = transform.position;

        Destroy(gameObject, destroyCooldown);
    }
}
