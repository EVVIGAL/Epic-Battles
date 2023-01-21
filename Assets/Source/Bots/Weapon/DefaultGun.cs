using UnityEngine;

public abstract class DefaultGun : Weapon
{
    [SerializeField] private Shell _bulletTemplate;
    [SerializeField] private ParticleSystem _shootFX;

    protected override void OnShoot(Transform target = null)
    {
        Vector3 shootPoint = GetShootPoint();
        Vector3 targetPosition = target != null ? target.position + target.up : transform.forward;
        Vector3 direction = (targetPosition - shootPoint).normalized;
        Quaternion rotation = GetRotation(direction);
        Shell newShell = Instantiate(_bulletTemplate, shootPoint, rotation);
        newShell.Init(Damage);

        if (_shootFX != null)
            Instantiate(_shootFX, shootPoint, rotation);
    }

    protected abstract Vector3 GetShootPoint();

    protected virtual Quaternion GetRotation(Vector3 direction)
    {
        return Quaternion.LookRotation(direction);
    }
}