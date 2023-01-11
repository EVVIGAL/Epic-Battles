using UnityEngine;

public class DefaultGun : Weapon
{
    [SerializeField] private Bullet<RedTeam> _bulletTemplate;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private ParticleSystem _shootFX;

    protected override void OnShoot(Transform target)
    {
        Vector3 direction = (target.position + target.up - _shootPoint.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        Instantiate(_bulletTemplate, _shootPoint.position, rotation);

        if (_shootFX != null)
            Instantiate(_shootFX, _shootPoint.position, rotation);
    }
}