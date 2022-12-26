using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class Move : Action
{
    public MonoBehaviour MovementSource;
    public SharedVector2 Direction;

    private IMovement Movement => (IMovement)MovementSource;

    public override TaskStatus OnUpdate()
    {
        Movement.Move(Direction.Value);
        return TaskStatus.Running;
    }
}