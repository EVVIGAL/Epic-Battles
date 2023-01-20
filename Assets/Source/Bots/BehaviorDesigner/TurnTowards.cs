using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class TurnTowards : Action
{
    public SharedTransform Target;
    public SharedFloat AngularSpeed = 1;

    public override TaskStatus OnUpdate()
    {
        Vector3 direction = Target.Value.position - transform.position;
        direction.y = 0f;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction), AngularSpeed.Value);

        if (Vector3.Angle(transform.forward, direction) < 1f)
            return TaskStatus.Success;

        return TaskStatus.Running;
    }
}