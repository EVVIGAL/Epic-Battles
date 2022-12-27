using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetNearbyObject : Action
{
    public SharedTransform Target;
    public Team EnemyTeam;

    public override TaskStatus OnUpdate()
    {
        Transform target = EnemyTeam.GetNearbyObject(transform.position);
        if (target == null)
            return TaskStatus.Failure;

        Target.Value = target;
        return TaskStatus.Success;
    }
}