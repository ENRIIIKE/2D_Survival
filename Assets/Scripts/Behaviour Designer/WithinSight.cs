using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class WithinSight : Conditional
{
    // How wide of an angle the object can see
    public float attackDistance;
    // The tag of the targets
    public string targetTag;
    // Set the target variable when a target has been found so the subsequent tasks know which object is the target
    public SharedTransform target;

    // A cache of all of the possible targets
    private Transform[] possibleTargets;

    public override void OnAwake()
    {
        // Cache all of the transforms that have a tag of targetTag
        var targets = GameObject.FindGameObjectsWithTag(targetTag);
        possibleTargets = new Transform[targets.Length];
        for (int i = 0; i < targets.Length; ++i)
        {
            possibleTargets[i] = targets[i].transform;
        }
    }

    public override TaskStatus OnUpdate()
    {
        // Return success if a target is within sight
        for (int i = 0; i < possibleTargets.Length; ++i)
        {
            if (WithinSightBool(possibleTargets[i], attackDistance))
            {
                // Set the target so other tasks will know which transform is within sight
                target.Value = possibleTargets[i];
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }

    // Returns true if targetTransform is within sight of current transform
    public bool WithinSightBool(Transform targetTransform, float attackDistance)
    {
        var distance = Vector2.Distance(transform.position, targetTransform.position);

        if (distance <= attackDistance)
        {
            return true;
        }
        else return false;
    }
}