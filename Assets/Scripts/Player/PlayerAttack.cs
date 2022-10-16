using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public WeaponsSO weaponSO;
    public GameObject direction;

    [HideInInspector] 
    public CalculateAim calculateAim;

    private float attackTime;

    private void Start()
    {
        calculateAim = direction.GetComponent<CalculateAim>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            if (!CanAttack()) return;
            weaponSO.Attack(this);
            ResetAttackTime();
        }
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
    private void ResetAttackTime()
    {
        attackTime = Time.time + weaponSO.attackSpeed;
    }
}
