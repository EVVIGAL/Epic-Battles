using UnityEngine;

[RequireComponent (typeof(Animator), (typeof(CharacterController)), typeof(Movement))]
public class HumanHealth : Health
{
    [SerializeField] private MonoBehaviour _ragdollSource;
    private IRagdoll _ragdoll => (IRagdoll)_ragdollSource;

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
    }

    private void OnValidate()
    {
        if (_ragdollSource && !(_ragdollSource is IRagdoll))
        {
            Debug.LogError(nameof(_ragdollSource) + " is not implement + " + nameof(IRagdoll));
            _ragdollSource = null;
        }
    }
}