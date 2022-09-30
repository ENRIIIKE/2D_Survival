using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType { Melee, Ranged }

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Objects/New Weapon")]
public class WeaponsSO : ScriptableObject
{
    [Header("General")]
    public string itemName;
    public int itemID;
    public AttackType attackType;

    [Header("Weapon Stats")]
    public int damage;
    public float attackSpeed;

    [Header("Melee Weapon")]
    public float swingRadius;

    [Header("Ranged Weapon")]
    public GameObject projectile;
    public float speedOfProjectile;
}
