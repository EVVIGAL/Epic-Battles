using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterControllerMovement : Movement
{
    protected CharacterController CharacterController { get; private set; }

    private void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Rotate();
        Vector3 movement = Direction == Vector3.zero ? Vector3.zero : transform.forward * CurrentSpeed;
        Move(movement);
        Direction = Vector3.zero;
    }

    protected virtual void Move(Vector3 delta)
    {
        CharacterController.SimpleMove(delta);
    }
}