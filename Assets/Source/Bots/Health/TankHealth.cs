using UnityEngine;

public class TankHealth : Health
{
    [SerializeField] private Rigidbody _turretRigidbody;
    [SerializeField] private float _explosionForce;

    protected override void Die()
    {
        _turretRigidbody.transform.parent = null;
        _turretRigidbody.isKinematic = false;
        _turretRigidbody.AddForce(transform.up * _explosionForce, ForceMode.Impulse);
    }
}