using BehaviorDesigner.Runtime.Tasks;

public class Attack : Action
{
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
