using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Weapon", menuName =
    "New Item/Ranged Weapon")]
public class WeaponRangedSO : WeaponsSO
{
    [Header("Ranged Weapon")]
    public GameObject projectile;
    public float speedOfProjectile;

    public override void Attack()
    {
        base.Attack();

    }
}
