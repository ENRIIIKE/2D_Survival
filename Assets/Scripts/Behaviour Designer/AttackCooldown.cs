using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class AttackCooldown : Conditional
{
    // Cooldown time
    public float cooldownTime;

    // Actual cooldown timer
    public float cooldown;

    // Target shared variable
    public SharedTransform target;

    public override void OnAwake()
    {
        cooldown = Time.time + 1f;
    }
    public override TaskStatus OnUpdate()
    {
        if (cooldown > Time.time)
        {
            cooldown = Time.time + cooldownTime;
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }
    }
}