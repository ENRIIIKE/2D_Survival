using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Attack : Action
{
    public SharedFloat attackDistance;
    // To controll Attack Function
    private EntityController controller;

    public override void OnAwake()
    {
        controller = GetComponent<EntityController>();
    }
    public override TaskStatus OnUpdate()
    {
        controller.Attack();
        return TaskStatus.Success;
    }
}
