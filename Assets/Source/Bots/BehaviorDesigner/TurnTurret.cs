using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class TurnTurret : Action
{
    public Transform Turret;
    public SharedTransform Target;
    public float AngularSpeed = 1;

    public override TaskStatus OnUpdate()
    {
        Vector3 direction = Target.Value.position - Turret.position;
        direction.y = 0f;
        Turret.rotation = Quaternion.RotateTowards(Turret.rotation, Quaternion.LookRotation(direction), AngularSpeed);
        if (Vector3.Angle(Turret.forward, direction) < 1f)
            return TaskStatus.Success;

        return TaskStatus.Running;
    }
}