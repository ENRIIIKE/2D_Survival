using UnityEngine;

public enum EntityAttackType { Melee, Ranged}
//public enum EntityRarityType { Common, Rare, Epic, Legendary}
[CreateAssetMenu(fileName = "New Entity", menuName = "Scriptable Objects/New Entity")]
public class EntitySo : ScriptableObject
{
    [Header("General")]
    public string entityName;
    public int entityID;
    public string description;


    [Header("Stats")]
    public EntityAttackType entityAttackType;
    //public EntityRarityType entityRarityType;
    [Tooltip("Speed of the entity")] 
    public float movementSpeed;
    [Tooltip("Wait till entity can attack again")] 
    public float attackSpeed;
    [Tooltip("How far can entity be to attack the player")] 
    public float attackDistance;
    [Tooltip("Entity will spot player within entered distance")] 
    public float seekDistance;
    
    /* ENTITY DAMAGE SYSTEM DOES NOT EXIST CURRENTLY
    public int damage;
    */

}
