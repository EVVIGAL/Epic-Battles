using UnityEngine;

[RequireComponent (typeof(HumanAnimator))]
public class SoldierGun : DefaultGun
{
    private HumanAnimator _humanAnimator;

    private void Start()
    {
        _humanAnimator = GetComponent<HumanAnimator>();
    }

    protected override void OnShoot(Transform target)
    {
        base.OnShoot(target);
        _humanAnimator.Shoot();
    }

    protected override void OnReload()
    {
        base.OnReload();
        _humanAnimator.Reload();
    }
}