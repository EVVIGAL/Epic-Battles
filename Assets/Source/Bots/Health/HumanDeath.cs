using UnityEngine;

public class HumanDeath : Death
{
    [SerializeField] private MonoBehaviour _ragdollSource;
    private IRagdoll _ragdoll => (IRagdoll)_ragdollSource;

    protected override void OnFell()
    {
        base.OnFell();
        _ragdoll.Disable();
    }
}