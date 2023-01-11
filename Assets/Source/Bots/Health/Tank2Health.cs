using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Movement))]
public class Tank2Health : Health
{
    [SerializeField] private TurelExplosion _turelExplosion;
    [SerializeField] private Collider _bodyCollider;

    private Rigidbody _rigidbody;
    private Movement _movement;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _movement = GetComponent<Movement>();
    }

    protected override void Die()
    {
        base.Die();
        _turelExplosion.Explose();
        _rigidbody.isKinematic = true;
        _movement.enabled = false;
        _bodyCollider.enabled = false;
    }
}