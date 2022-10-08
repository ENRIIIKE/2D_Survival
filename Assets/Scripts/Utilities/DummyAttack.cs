using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform aimTransform;
    public Transform temporaryTransform;

    public int damage;
    public float attackSpeed;
    public float projectileSpeed;

    private float attackTime;

    private void Start()
    {
        attackTime = Time.time + attackSpeed;
    }
    void Update()
    {
        if (attackTime < Time.time)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab, aimTransform.position,
                Quaternion.identity, temporaryTransform);

            Projectile projectileInstanceScript = projectileInstance.GetComponent<Projectile>();
            projectileInstanceScript.damage = damage;
            projectileInstanceScript.shooter = gameObject;

            projectileInstance.GetComponent<Rigidbody2D>().AddForce(transform.right * projectileSpeed, ForceMode2D.Impulse);

            attackTime = Time.time + attackSpeed;
        }
    }
}
