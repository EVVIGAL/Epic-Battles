using UnityEngine;

[RequireComponent (typeof(Animator), (typeof(CharacterController)), typeof(Movement))]
public class HumanHealth : Health
{
    [SerializeField] private MonoBehaviour _ragdollSource;
    private IRagdoll _ragdoll => (IRagdoll)_ragdollSource;

    [SerializeField] private MonoBehaviour _weaponPhysicSource;
    private IObjectPhysics _weaponPhysics => (IObjectPhysics)_weaponPhysicSource;

    private CharacterController _characterController;
    private Movement _movement;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _movement = GetComponent<Movement>();
    }

    protected override void Die()
    {
        base.Die();
        _ragdoll.Enable();
        _animator.enabled = false;
        _characterController.enabled = false;
        _movement.enabled = false;
        _weaponPhysics.Enable();
    }

    private void OnValidate()
    {
        if (_ragdollSource && !(_ragdollSource is IRagdoll))
        {
            Debug.LogError(nameof(_ragdollSource) + " is not implement + " + nameof(IRagdoll));
            _ragdollSource = null;
        }

        if (_weaponPhysicSource && !(_weaponPhysicSource is IObjectPhysics))
        {
            Debug.LogError(nameof(_weaponPhysicSource) + " is not implement + " + nameof(IObjectPhysics));
            _weaponPhysicSource = null;
        }
    }
}