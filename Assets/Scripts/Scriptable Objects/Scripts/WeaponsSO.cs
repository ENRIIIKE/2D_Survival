using UnityEngine;

public class WeaponsSO : Equipment
{
    [Header("Weapon Stats")]
    public int damage;
    public float attackSpeed;

    [Header("Entity Layer")]
    public LayerMask entityLayer;

    public virtual void Attack(PlayerAttack playerAttack)
    {
        //Code
    }
}
