using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetNearbyObject : Conditional
{
    public SharedTransform Target;
    public SharedTeam EnemyTeam;

    public override TaskStatus OnUpdate()
    {
        Transform target = EnemyTeam.Value.GetNearbyBot(transform.position);
        if (target == null)
            return TaskStatus.Failure;

        Target.Value = target;
        return TaskStatus.Success;
    }
}