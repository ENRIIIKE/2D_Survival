using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class EntityIdle : Action
{
    [SerializeField]
    private float idleDistance;

    [SerializeField] 
    private SharedFloat movementSpeed;
    public override TaskStatus OnUpdate()
    {
        
        var position = transform.position;
        
        // Find new idle position
        var newPosX = Random.Range(position.x - idleDistance, position.x + idleDistance);
        var newPosY = Random.Range(position.y - idleDistance, position.y + idleDistance);

        var newVector = new Vector3(newPosX, newPosY);
        
        // If entity is on the new position, task will return success and will move on
        if (position == newVector)
        {
            return TaskStatus.Success;
        }
        
        // Move towards the new idle position and returns task status as running
        position = Vector3.MoveTowards(position, newVector, movementSpeed.Value * Time.deltaTime);
        transform.position = position;
        
        return TaskStatus.Running;
    }
}
