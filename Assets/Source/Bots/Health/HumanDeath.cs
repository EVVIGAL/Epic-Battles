using UnityEngine;

public class HumanDeath : Death
{
    [SerializeField] private MonoBehaviour _ragdollSource;
    private IObjectPhysics _ragdoll => (IObjectPhysics)_ragdollSource;

    [SerializeField] private MonoBehaviour _weaponPhysicSource;
    private IObjectPhysics _weaponPhysics => (IObjectPhysics)_weaponPhysicSource;

    protected override void OnFell()
    {
        base.OnFell();
        _ragdoll.Disable();
        _weaponPhysics.Disable();
    }

    private void OnValidate()
    {
        if (_ragdollSource && !(_ragdollSource is IObjectPhysics))
        {
            Debug.LogError(nameof(_ragdollSource) + " needs to implement " + nameof(_ragdollSource));
            _ragdollSource = null;
        }
        if (_weaponPhysicSource && !(_weaponPhysicSource is IObjectPhysics))
        {
            Debug.LogError(nameof(_weaponPhysicSource) + " needs to implement " + nameof(_weaponPhysicSource));
            _weaponPhysicSource = null;
        }
    }
}