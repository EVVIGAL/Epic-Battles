using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterControllerMovement : Movement
{
    private CharacterController _characterController;

    private Vector3 _direction;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Rotate(_direction);
        Vector3 movement = _direction == Vector3.zero ? Vector3.zero : transform.forward * MoveSpeed;
        _characterController.SimpleMove(movement);
        _direction = Vector3.zero;
    }

    public override void Move(Vector2 direction)
    {
        _direction = direction;
    }

    private void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return;

        Quaternion rotate = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.y));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotate, AngularSpeed * Time.deltaTime);
    }
}