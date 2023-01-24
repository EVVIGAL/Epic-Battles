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
}