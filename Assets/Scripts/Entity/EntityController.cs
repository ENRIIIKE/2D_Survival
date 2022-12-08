using UnityEngine;
//using BehaviorDesigner.Runtime;

public abstract class EntityController : MonoBehaviour
{
    [Header("General")]
    public EntitySO entitySo;
    private Transform temporaryObjects;

    /*[Header("Behaviour Tree")] 
    private BehaviorTree behaviourTree;
    
    [SerializeField, Tooltip("Speed of the entity")]
    private float speed;
    
    [SerializeField, Tooltip("Wait till entity can attack again")] 
    private float attackCooldown;
    
    [SerializeField, Tooltip("How far can entity be to attack the player")] 
    private float attackDistance;
    
    [SerializeField, Tooltip("Entity will spot player within entered distance")] 
    private float seekDistance;*/

    //[Space]
    //[SerializeField] private bool showGizmos = false;


    private void Awake()
    {
        temporaryObjects = GameObject.Find("--Temporary--").transform;
        // behaviourTree = GetComponent<BehaviorTree>();
        //
        // behaviourTree.SetVariableValue("Speed", speed);
        // behaviourTree.SetVariableValue("Attack Cooldown", attackCooldown);
        // behaviourTree.SetVariableValue("Attack Distance", attackDistance);
        // behaviourTree.SetVariableValue("Seek Distance", seekDistance);
    }

    public abstract void Attack();

}
