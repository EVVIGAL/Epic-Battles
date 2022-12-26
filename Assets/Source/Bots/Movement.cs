using UnityEngine;

public abstract class Movement : MonoBehaviour, IMovement
{
    [field: SerializeField] public float MoveSpeed { get; set; }
    [field: SerializeField] public float AngularSpeed { get; set; }

    public abstract void Move(Vector2 direction);
}