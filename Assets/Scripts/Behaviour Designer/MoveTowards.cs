using System;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Action = BehaviorDesigner.Runtime.Tasks.Action;

[Serializable]
public class MoveTowards : Action
{
    // The distance to attack player
    [SerializeField]
    private SharedFloat attackDistance;
    // The distance to spot and hunt player
    [SerializeField]
    private SharedFloat seekDistance;
    // The speed of the object
    [SerializeField]
    private SharedFloat movementSpeed;
    // The transform that the object is moving towards
    [SerializeField]
    private SharedTransform target;

    public override TaskStatus OnUpdate()
    {
        var distance = Vector2.Distance(transform.position, target.Value.position);
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
        transform.position = Vector3.MoveTowards(transform.position, target.Value.position, movementSpeed.Value * Time.deltaTime);
        return TaskStatus.Running;
    }
}