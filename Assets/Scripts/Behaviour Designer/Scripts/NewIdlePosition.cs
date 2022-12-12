using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class NewIdlePosition : Action
{
    [SerializeField]
    private SharedFloat idleDistance;
    
    [SerializeField]
    private SharedVector3 newPosition;

    public override TaskStatus OnUpdate()
    {
        var position = transform.position;

        var newPosition = Vector3.zero;
        
        // Find new idle position
        var newPosX = Random.Range(position.x - idleDistance.Value, position.x + idleDistance.Value);
        var newPosY = Random.Range(position.y - idleDistance.Value, position.y + idleDistance.Value);

        newPosition = new Vector3(newPosX, newPosY);

        return TaskStatus.Success;
    }
}