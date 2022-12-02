using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Attack : Action
{
    public SharedFloat attackDistance;
    // To control Attack Function
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
