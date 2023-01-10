using UnityEngine;

public class Ragdoll : MonoBehaviour, IRagdoll
{
    private Rigidbody[] _rigidbodies;
    private Collider[] _colliders;

    private void Awake()
    {
        _rigidbodies = GetComponentsInChildren<Rigidbody>();
        _colliders = GetComponentsInChildren<Collider>();
        Disable();
    }

    public void Enable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = false;

        foreach (Collider collider in _colliders)
            collider.isTrigger = false;
    }

    public void Disable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = true;

        foreach (Collider collider in _colliders)
            collider.isTrigger = true;
    }
}