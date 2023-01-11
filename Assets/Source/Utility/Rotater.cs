using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private Transform _turret;
    [SerializeField] private Transform _gun;
    [SerializeField] private Transform _target;
    [SerializeField] private float _angularSpeed;
    [SerializeField] private float _rayDistance;

    private Vector3 _direction;
    private Vector3 _direction2;

    private void Update()
    {
        _direction = (_target.position - _turret.position).normalized;
        Quaternion turretDirection = Quaternion.LookRotation(_direction);
        _turret.rotation = Quaternion.RotateTowards(_turret.rotation, turretDirection, _angularSpeed * Time.deltaTime);
        _turret.localEulerAngles = new Vector3(0f, _turret.localEulerAngles.y, 0f);

        _direction2 = (_target.position - _gun.position).normalized;
        Quaternion gunDirection = Quaternion.LookRotation(_direction2);
        _gun.rotation = Quaternion.RotateTowards(_gun.rotation, gunDirection, _angularSpeed * Time.deltaTime);
        _gun.localEulerAngles = new Vector3(_gun.localEulerAngles.x, 0f, 0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(_turret.position, _turret.forward * _rayDistance);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(_gun.position, _gun.forward * _rayDistance);
    }
}