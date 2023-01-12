using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Movement), typeof(Collider))]
public class TankHealth : Health
{
    [SerializeField] private TurelExplosion _turelExplosion;

    private CharacterController _characterController;
    private Movement _movement;
    private Collider _collider;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
        _collider = GetComponent<Collider>();
    }

    protected override void Die()
    {
        base.Die();
        _turelExplosion.Explose();
        _characterController.enabled = false;
        _movement.enabled = false;
        _collider.enabled = false;
    }
}