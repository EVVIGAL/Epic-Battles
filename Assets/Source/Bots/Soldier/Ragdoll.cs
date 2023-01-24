using System;
using UnityEngine;

public class Ragdoll : MonoBehaviour, IObjectPhysics
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Collider[] _colliders;

    public bool IsActive => !_rigidbodies[0].isKinematic;

    private void Awake()
    {
        Disable();
    }

    public void Enable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = false;

        foreach (Collider collider in _colliders)
            collider.enabled = true;
    }

    public void Disable()
    {
        foreach (Rigidbody rigidbody in _rigidbodies)
            rigidbody.isKinematic = true;

        foreach (Collider collider in _colliders)
            collider.enabled = false;
    }

    public void AddForce(Vector3 force)
    {
        if (IsActive == false)
            throw new InvalidOperationException();

        _rigidbodies[UnityEngine.Random.Range(0, _rigidbodies.Length)].AddForce(force, ForceMode.Impulse);
    }
}