using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "New Ranged Weapon", menuName =
    "New Item/Ranged Weapon")]
public class WeaponRangedSO : WeaponsSO
{
    [Header("Ranged Weapon")]
    public GameObject projectile;
    public float speedOfProjectile;

    public override void Attack(PlayerAttack playerAttack)
    {
        base.Attack(playerAttack);

        GameObject projectilePrefab = projectile;
        GameObject direction = playerAttack.direction;
        CalculateAim calculateAim = playerAttack.calculateAim;

        Vector3 directionNormalized = Vector3.Normalize(direction.transform.localPosition);

        GameObject projectileInstance = Instantiate(projectilePrefab, direction.transform.position,
            Quaternion.identity, null);
        Projectile projectileInstanceScript = projectileInstance.GetComponent<Projectile>();

        projectileInstanceScript.damage = damage;
        projectileInstanceScript.shooter = playerAttack.transform;

        projectileInstance.GetComponent<Rigidbody2D>().AddForce(directionNormalized *
            speedOfProjectile, ForceMode2D.Impulse);

        var dir = Input.mousePosition - calculateAim.cam.WorldToScreenPoint(playerAttack.transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        projectileInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
