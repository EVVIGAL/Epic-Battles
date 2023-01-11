using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckDistance : Conditional
{
    public SharedTransform Target;
    public SharedAttackDistance Distance;

    public override TaskStatus OnUpdate()
    {
        float result = Vector3.Distance(transform.position, Target.Value.position);
        if (result <= Distance.Value.Value)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}