using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Chase : Move
{
    public SharedTransform Target;

    public override TaskStatus OnUpdate()
    {
        Vector3 direction = (Target.Value.position - transform.position).normalized;
        Direction.Value = new Vector2(direction.x, direction.z);
        return base.OnUpdate();
    }
}