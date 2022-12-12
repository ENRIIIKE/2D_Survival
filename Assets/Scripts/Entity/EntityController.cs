using UnityEngine;
using BehaviorDesigner.Runtime;


public class EntityController : MonoBehaviour
{
    [Header("General")]
    public EntitySo entitySo;
    
    // GameObject will be instantiated as a child of a temporary Object to have it more clean. 
    //
    //private Transform temporaryObjects;

    [Header("Behaviour Tree")] 
    public BehaviorTree behaviourTree;
    
    private void Awake()
    {
        //temporaryObjects = GameObject.Find("--Temporary--").transform;
        
        behaviourTree = GetComponent<BehaviorTree>();
        
        behaviourTree.SetVariableValue("Movement Speed", entitySo.movementSpeed);
        behaviourTree.SetVariableValue("Attack Cooldown", entitySo.attackSpeed);
        behaviourTree.SetVariableValue("Attack Distance", entitySo.attackDistance);
        behaviourTree.SetVariableValue("Seek Distance", entitySo.seekDistance);
    }

    public void Attack()
    {
        //Attack code
        Debug.Log(entitySo.name + " is attacking.");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, entitySo.seekDistance);
    }
}
