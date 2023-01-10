using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class PhysicsMovement : Movement
{
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Rotate();
        Vector3 movement = Direction == Vector3.zero ? Vector3.zero : transform.forward * CurrentSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + movement);
        Direction = Vector3.zero;
    }
}