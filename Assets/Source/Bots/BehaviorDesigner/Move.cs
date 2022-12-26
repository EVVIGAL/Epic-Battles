using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Move : Action
{
    public MonoBehaviour MovementSource;
    public SharedVector2 Direction;

    private IMovement _movement => (IMovement)MovementSource;

    public override TaskStatus OnUpdate()
    {
        _movement.Move(Direction.Value);
        return TaskStatus.Running;
    }
}