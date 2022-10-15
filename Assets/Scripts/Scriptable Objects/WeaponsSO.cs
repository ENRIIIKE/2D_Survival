using UnityEngine;

public enum AttackType { Melee, Ranged }

public class WeaponsSO : ItemData
{
    public AttackType attackType;

    [Header("Weapon Stats")]
    public int damage;
    public float attackSpeed;
    public virtual void Attack()
    {
        Debug.Log("Using " + name);
    }
}
