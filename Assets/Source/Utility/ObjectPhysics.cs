using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class ObjectPhysics : MonoBehaviour, IObjectPhysics
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public bool IsActive => !_rigidbody.isKinematic;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void Enable()
    {
        _rigidbody.isKinematic = false;
        _collider.enabled = true;
    }

    public void Disable()
    {
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
    }

    public void AddForce(Vector3 force)
    {
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
}