using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class TurnTurret : Action
{
    public Transform Turret;
    public Transform Gun;
    public SharedTransform Target;
    public float AngularSpeed = 1;

    public override TaskStatus OnUpdate()
    {
        Vector3 direction = (Target.Value.position + Vector3.up - Turret.position).normalized;
        var turretDirection = new Vector3(direction.x, 0f, direction.z);
        var gunDirection = new Vector3(0f, direction.y, 0f);

        Turret.rotation = Quaternion.RotateTowards(Turret.rotation, Quaternion.LookRotation(turretDirection), AngularSpeed);
        Gun.rotation = Quaternion.RotateTowards(Gun.rotation, Quaternion.LookRotation(direction), AngularSpeed);
        if (Vector3.Angle(Turret.forward, turretDirection) < 1f && Vector3.Angle(Gun.forward, direction) < 1f)
            return TaskStatus.Success;

        return TaskStatus.Running;
    }
}