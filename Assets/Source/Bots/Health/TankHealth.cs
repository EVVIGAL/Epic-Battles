using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Movement))]
public class TankHealth : Health
{
    [SerializeField] private TurelExplosion _turelExplosion;
    [SerializeField] private Collider _bodyCollider;

    private CharacterController _characterController;
    private Movement _movement;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
    }

    protected override void Die()
    {
        base.Die();
        _turelExplosion.Explose();
        _characterController.enabled = false;
        _movement.enabled = false;
        _bodyCollider.enabled = false;
    }
}