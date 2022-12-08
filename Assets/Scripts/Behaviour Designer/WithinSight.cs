using System;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[Serializable]
public class WithinSight : Conditional
{
    // How wide of an angle the object can see
    [SerializeField]
    private SharedFloat seekDistance;
    // The tag of the targets
    [SerializeField]
    private string targetTag;
    // Set the target variable when a target has been found so the subsequent tasks know which object is the target
    [SerializeField]
    private SharedTransform target;

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
        foreach (var t in possibleTargets)
        {
            if (WithinSightBool(t, seekDistance.Value))
            {
                // Set the target so other tasks will know which transform is within sight
                target.Value = t;
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }

    // Returns true if targetTransform is within sight of current transform
    private bool WithinSightBool(Transform targetTransform, float attackDistance)
    {
        var distance = Vector2.Distance(transform.position, targetTransform.position);

        if (distance <= attackDistance)
        {
            return true;
        }
        else return false;
    }
}