using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class ObjectPhysics : MonoBehaviour, IObjectPhysics
{
    private Rigidbody _rigidbody;
    private Collider _collider;

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
}