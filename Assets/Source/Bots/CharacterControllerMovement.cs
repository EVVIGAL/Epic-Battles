using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterControllerMovement : Movement
{
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    public override void Move(Vector2 direction)
    {
        Rotate(direction);
        _characterController.SimpleMove(transform.forward * MoveSpeed);
    }

    private void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;

        Quaternion rotate = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, AngularSpeed * Time.deltaTime);
    }
}