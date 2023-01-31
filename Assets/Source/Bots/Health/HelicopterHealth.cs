using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(CapsuleCollider), typeof(Movement))]
[RequireComponent(typeof(Animator), typeof(CharacterController))]
public class HelicopterHealth : Health
{
    [SerializeField] private ObjectPhysics[] _objectPhysics;
    [SerializeField] private float _torqueForce;

    private Rigidbody _rigidbody;
    private CapsuleCollider _capsuleCollider;
    private Movement _movement;
    private Animator _animator;
    private CharacterController _characterController;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _movement = GetComponent<Movement>();
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
    }

    protected override void Die()
    {
        base.Die();
        _rigidbody.isKinematic = false;
        _capsuleCollider.enabled = true;
        _rigidbody.AddRelativeTorque(Vector3.up * _torqueForce, ForceMode.Impulse);
        _movement.enabled = false;
        _animator.enabled = false;
        _characterController.enabled = false;
        foreach (ObjectPhysics objectPhysics in _objectPhysics)
            objectPhysics.Enable();
    }
}