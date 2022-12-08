using UnityEngine;
using BehaviorDesigner.Runtime;

public class EntityController : MonoBehaviour
{
    [Header("General")]
    public EntitySo entitySo;
    private Transform temporaryObjects;

    [Header("Behaviour Tree")] 
    private BehaviorTree behaviourTree;
    
    private void Awake()
    {
        temporaryObjects = GameObject.Find("--Temporary--").transform;
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
}
