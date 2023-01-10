using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class TakeAim : Action
{
    public SharedTransform Target;
    public Transform Aim;

    public override TaskStatus OnUpdate()
    {
        Vector3 direction = Target.Value.position + Vector3.up - Aim.position;
        Aim.rotation = Quaternion.LookRotation(direction);
        return TaskStatus.Success;
    }
}