using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EntityAttackType { Melee, Ranged}
//public enum EntityRarityType { Common, Rare, Epic, Legendary}
[CreateAssetMenu(fileName = "New Entity", menuName = "Scriptable Objects/New Entity")]
public class EntitySO : ScriptableObject
{
    [Header("General")]
    public string entityName;
    public int entityID;
    public string description;


    [Header("Stats")]
    public EntityAttackType entityAttackType;
    //public EntityRarityType entityRarityType;
    public float movementSpeed;
    public float attackType;
    public int damage;

}
