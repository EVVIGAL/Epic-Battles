using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class CharacterControllerMovement : Movement
{
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Rotate();
        Vector3 movement = Direction == Vector3.zero ? Vector3.zero : transform.forward * CurrentSpeed;
        _characterController.SimpleMove(movement);
        Direction = Vector3.zero;
    }
}