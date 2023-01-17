using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class HelicopterDeath : Death
{
    [SerializeField] private ObjectPhysics[] _objectPhysics;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected override void OnFell()
    {
        base.OnFell();
        _rigidbody.isKinematic = true;
        foreach (ObjectPhysics objectPhysics in _objectPhysics)
            objectPhysics.Disable();
    }
}