using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = 
    "New Item/Melee Weapon")]
public class WeaponMeleeSO : WeaponsSO
{
    [Header("Melee Weapon Stats")]
    public float swingRadius;

    public override void Attack(PlayerAttack playerAttack)
    {
        base.Attack(playerAttack);

        GameObject direction = playerAttack.direction;
        Collider2D[] hits = Physics2D.OverlapCircleAll(direction.transform.position,
        swingRadius, entityLayer);

        foreach (Collider2D hit in hits)
        {
            Debug.Log(hit.name);
            
            IDamagable damagable = hit.GetComponent<IDamagable>();

            damagable.GetDamage(damage);

        }
    }
}
