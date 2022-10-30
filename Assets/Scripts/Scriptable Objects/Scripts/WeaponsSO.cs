using UnityEngine;

public class WeaponsSO : Equipment
{
    [Header("Weapon Stats")]
    public int damage;
    public float attackSpeed;
    public LayerMask entityLayer;

    private void Awake()
    {
        equipmentType = EquipmentType.Weapon;
    }
}
