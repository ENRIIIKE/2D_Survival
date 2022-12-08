using UnityEngine;
using BehaviorDesigner.Runtime;

public abstract class EntityController : MonoBehaviour
{
    [Header("General")]
    public EntitySo entitySo;
    private Transform temporaryObjects;

    [Header("Behaviour Tree")] 
    private BehaviorTree behaviourTree;
    

    //[Space]
    //[SerializeField] private bool showGizmos = false;


    private void Awake()
    {
        temporaryObjects = GameObject.Find("--Temporary--").transform;
        behaviourTree = GetComponent<BehaviorTree>();
        
        behaviourTree.SetVariableValue("Movement Speed", entitySo.movementSpeed);
        behaviourTree.SetVariableValue("Attack Cooldown", entitySo.attackSpeed);
        behaviourTree.SetVariableValue("Attack Distance", entitySo.attackDistance);
        behaviourTree.SetVariableValue("Seek Distance", entitySo.seekDistance);
    }

    public abstract void Attack();

}
