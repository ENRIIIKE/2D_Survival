using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    private EquipmentManager equipmentManager;
    [SerializeField]
    private WeaponsSO activeWeapon;

    public GameObject direction;

    [HideInInspector] 
    public CalculateAim calculateAim;

    private float attackTime;

    private void Start()
    {
        calculateAim = direction.GetComponent<CalculateAim>();
        equipmentManager = EquipmentManager.instance;

        equipmentManager.equipmentCallback += UpdateActiveWeapon;
    }
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            //Try to optimize these IFs
            if (activeWeapon == null) return;
            if (EventSystem.current.IsPointerOverGameObject()) return;
            if (!CanAttack()) return;

            activeWeapon.UseOne(this);

            attackTime = Time.time + activeWeapon.attackSpeed;
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

    public void UpdateActiveWeapon()
    {
        activeWeapon = (WeaponsSO)equipmentManager.currentEquipment[4];
    }

}
