using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = 
    "New Item/Melee Weapon")]
public class WeaponMeleeSO : WeaponsSO
{
    [Header("Melee Weapon Stats")]
    public float swingRadius;

    public override void Attack()
    {
        base.Attack();
    }
}
