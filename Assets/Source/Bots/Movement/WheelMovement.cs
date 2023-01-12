using UnityEngine;

public class WheelMovement : Movement
{
    [SerializeField] private WheelCollider[] _wheelColliders;
    [SerializeField] private float _brakeTorque = 200f;

    private void FixedUpdate()
    {
        Vector3 movement = Direction == Vector3.zero ? Vector3.zero : transform.forward * CurrentSpeed;

        if (movement != Vector3.zero)
        {
            foreach (WheelCollider wheelCollider in _wheelColliders)
            {
                wheelCollider.motorTorque = movement.magnitude;
                wheelCollider.steerAngle = Vector2.Angle(new Vector3(transform.forward.x, transform.forward.z), new Vector3(Direction.x, Direction.y));
                Direction = Vector3.zero;
            }
        }
        else
        {
            foreach (WheelCollider wheelCollider in _wheelColliders)
                wheelCollider.brakeTorque = _brakeTorque;
        }
    }
}