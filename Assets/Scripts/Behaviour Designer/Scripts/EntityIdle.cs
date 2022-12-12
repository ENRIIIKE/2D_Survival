using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class EntityIdle : Action
{
    [SerializeField] 
    private SharedFloat movementSpeed;

    [SerializeField] 
    private SharedVector3 newPosition;
    public override TaskStatus OnUpdate()
    {
        
        // If entity is on the new position, task will return success and will move on
        if (transform.position == newPosition.Value)
        {
            Debug.Log("Position");
            return TaskStatus.Success;
        }
        
        // Move towards the new idle position and returns task status as running
        transform.position = Vector3.MoveTowards(transform.position, newPosition.Value, movementSpeed.Value * Time.deltaTime);
        
        return TaskStatus.Running;
    }
}
