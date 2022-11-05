using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class MoveTowards : Action
{
    // The distance to attack player
    public SharedFloat attackDistance;
    // The distance to spot and hunt player
    public SharedFloat seekDistance;
    // The speed of the object
    public float speed = 0;
    // The transform that the object is moving towards
    public SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        float distance = Vector2.Distance(transform.position, target.Value.position);
        // Return a task status of success once we've reached the target
        if (distance <= attackDistance.Value)
        {
            return TaskStatus.Success;
        }
        
        // Check if target is still in a range
        if (distance >= seekDistance.Value)
        {
            return TaskStatus.Failure;
        }
        
        // We haven't reached the target yet so keep moving towards it
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, speed * Time.deltaTime);
        return TaskStatus.Running;
    }
}