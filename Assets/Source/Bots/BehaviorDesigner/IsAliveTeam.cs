using BehaviorDesigner.Runtime.Tasks;

public class IsAliveTeam : Conditional
{
    public SharedTeam Team;

    public override TaskStatus OnUpdate()
    {
        if (Team.Value.EnemyTeam.IsAlive)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}