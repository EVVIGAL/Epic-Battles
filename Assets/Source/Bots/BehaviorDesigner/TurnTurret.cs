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
        Vector3 direction = (Target.Value.position + Target.Value.up - Turret.position).normalized;
        var turretDirection = new Vector3(direction.x, 0f, direction.z);
        float speed = AngularSpeed * Time.deltaTime;

        Turret.rotation = Quaternion.RotateTowards(Turret.rotation, Quaternion.LookRotation(turretDirection), speed);
        Turret.localEulerAngles = new Vector3(0f, Turret.localEulerAngles.y, 0f);

        Gun.rotation = Quaternion.RotateTowards(Gun.rotation, Quaternion.LookRotation(direction), speed);
        Gun.localEulerAngles = new Vector3(Gun.localEulerAngles.x, 0f, 0f);

        if (Vector3.Angle(Turret.forward, turretDirection) < 1f && Vector3.Angle(Gun.forward, direction) < 1f)
            return TaskStatus.Success;

        return TaskStatus.Running;
    }
}