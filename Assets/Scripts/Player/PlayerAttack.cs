using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public WeaponsSO weaponSO;
    public Transform temporaryTransform;
    public GameObject direction;
    public LayerMask entityLayer;

    private float attackTime;
    private CalculateAim calculateAim;

    private void Start()
    {
        calculateAim = direction.GetComponent<CalculateAim>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            weaponSO.Attack();
        }
    }
    
    #region Melee
        /*
        if (!CanAttack()) return;
        
        

        Collider2D[] hits = Physics2D.OverlapCircleAll(direction.transform.position, 
            weaponSO.swingRadius, entityLayer);

        foreach (Collider2D hit in hits)
        {
            Debug.Log(hit.name);
            //Apply Damage;
        }
        
        ResetAttackTime();
        */
        #endregion

    #region Ranged
    /*
    GameObject projectilePrefab = weaponSO.projectile;
    Vector3 directionNormalized = Vector3.Normalize(direction.transform.localPosition);

    GameObject projectileInstance = Instantiate(projectilePrefab, direction.transform.position, 
        Quaternion.identity, null);
    Projectile projectileInstanceScript = projectileInstance.GetComponent<Projectile>();

    projectileInstance.transform.parent = temporaryTransform;

    projectileInstanceScript.damage = weaponSO.damage;
    projectileInstanceScript.shooter = gameObject;

    projectileInstance.GetComponent<Rigidbody2D>().AddForce(directionNormalized * 
        weaponSO.speedOfProjectile, ForceMode2D.Impulse);

    var dir = Input.mousePosition - calculateAim.cam.WorldToScreenPoint(transform.position);
    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    projectileInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    ResetAttackTime();
    */
    #endregion


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
    private void ResetAttackTime()
    {
        attackTime = Time.time + weaponSO.attackSpeed;
    }
}
