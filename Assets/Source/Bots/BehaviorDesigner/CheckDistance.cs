using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class CheckDistance : Conditional
{
    public SharedTransform Target;
    public SharedFloat Distance;

    public override TaskStatus OnUpdate()
    {
        float result = Vector3.Distance(transform.position, Target.Value.position);
        if (result <= Distance.Value)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}