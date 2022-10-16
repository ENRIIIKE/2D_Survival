using UnityEngine;

public class WeaponsSO : ItemData
{
    [Header("Weapon Stats")]
    public int damage;
    public float attackSpeed;

    public virtual void Attack()
    {
        Debug.Log("Using: " + itemName);
    }
}
