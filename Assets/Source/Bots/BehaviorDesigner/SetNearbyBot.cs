using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SetNearbyBot : Conditional
{
    public SharedBot Bot;
    public SharedTransform Target;

    public override TaskStatus OnUpdate()
    {
        Transform target = Bot.Value.Team.EnemyTeam.GetNearbyBot(Bot.Value);
        if (target == null)
            return TaskStatus.Failure;

        Target.Value = target;
        return TaskStatus.Success;
    }
}