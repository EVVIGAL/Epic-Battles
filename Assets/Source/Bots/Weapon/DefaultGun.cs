using UnityEngine;

public abstract class DefaultGun : Weapon
{
    [SerializeField] private MonoBehaviour _projectileFactoryBehaviour;
    private IProjectileFactory _projectileFactory => (IProjectileFactory)_projectileFactoryBehaviour;

    [SerializeField] private ParticleSystem _shootFX;

    protected override void OnShoot(Transform target = null)
    {
        Vector3 shootPoint = GetShootPoint();
        Vector3 targetPosition = target != null ? target.position + target.up : transform.forward;
        Vector3 direction = (targetPosition - shootPoint).normalized;
        Quaternion rotation = GetRotation(direction);

        IProjectile projectile = _projectileFactory.Create();
        if (projectile == null)
            return;

        projectile.Init(Damage, shootPoint, rotation);

        if (_shootFX != null)
            Instantiate(_shootFX, shootPoint, rotation);
    }

    protected abstract Vector3 GetShootPoint();

    protected virtual Quaternion GetRotation(Vector3 direction)
    {
        return Quaternion.LookRotation(direction);
    }

    private void OnValidate()
    {
        if (_projectileFactoryBehaviour && !(_projectileFactoryBehaviour is IProjectileFactory))
        {
            Debug.LogError(nameof(_projectileFactoryBehaviour) + " needs to implement " + nameof(IProjectileFactory));
            _projectileFactoryBehaviour = null;
        }
    }
}