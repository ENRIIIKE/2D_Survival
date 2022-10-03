using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public WeaponsSO weaponSO;
    public Transform temporaryTransform;
    public GameObject direction;
    private CalculateAim calculateAim;
    private AttackType attackType;
    public LayerMask entityLayer;

    private float attackTime;

    private void Start()
    {
        calculateAim = direction.GetComponent<CalculateAim>();

        attackType = weaponSO.attackType;

    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (attackType)
            {
                case AttackType.Melee:
                    MeleeAttack();
                    break;
                case AttackType.Ranged:
                    RangedAttack();
                    break;
                default:
                    Debug.LogWarning("Error has occured with the Player Attack script!", this);
                    break;
            }
        }
    }
    void MeleeAttack()
    {
        if (!CanAttack()) return;

        Collider2D[] hits = Physics2D.OverlapCircleAll(direction.transform.position, weaponSO.swingRadius, entityLayer);

        foreach (Collider2D hit in hits)
        {
            Debug.Log(hit.name);
            //Apply Damage;
        }

        attackTime = Time.time + weaponSO.attackSpeed;
    }
    void RangedAttack()
    {
        if (!CanAttack()) return;

        GameObject projectilePrefab = weaponSO.projectile;
        Vector3 directionNormalized = Vector3.Normalize(direction.transform.localPosition);

        GameObject projectileInstance = Instantiate(projectilePrefab, direction.transform.position, Quaternion.identity, null);
        Projectile projectileInstanceScript = projectileInstance.GetComponent<Projectile>();

        projectileInstance.transform.parent = temporaryTransform;

        projectileInstanceScript.damage = weaponSO.damage;
        projectileInstanceScript.shooter = gameObject;

        projectileInstance.GetComponent<Rigidbody2D>().AddForce(directionNormalized * weaponSO.speedOfProjectile, ForceMode2D.Impulse);

        var dir = Input.mousePosition - calculateAim.cam.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        projectileInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        attackTime = Time.time + weaponSO.attackSpeed;
    }

    private bool CanAttack()
    {
        if (attackTime > Time.time)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
