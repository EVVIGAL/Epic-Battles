using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(CapsuleCollider), typeof(Movement))]
public class HelicopterHealth : Health
{
    [SerializeField] private ObjectPhysics[] _objectPhysics;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private Movement _movement;
    private Animation _animation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _movement = GetComponent<Movement>();
        _animation = GetComponent<Animation>();
    }

    protected override void Die()
    {
        base.Die();
        _rigidbody.isKinematic = false;
        _capsuleCollider.enabled = true;
        _movement.enabled = false;
        _animation.Stop();
        _animation.enabled = false;
        foreach (ObjectPhysics objectPhysics in _objectPhysics)
            objectPhysics.Enable();
    }
}