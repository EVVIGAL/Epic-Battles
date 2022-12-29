using UnityEngine;

[RequireComponent (typeof(Animator))]
public class HumanHealth : Health
{
    [SerializeField] private MonoBehaviour _ragdollSource;
    private IRagdoll _ragdoll => (IRagdoll)_ragdollSource;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void Die()
    {
        _ragdoll.Enable();
        _animator.enabled = false;
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