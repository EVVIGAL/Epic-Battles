using UnityEngine;

public class MultiBarreledGun : Weapon
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform[] _shootPoint;
    [SerializeField] private ParticleSystem _shootFX;

    private int _currentBarrelIndex;

    protected override void OnShoot(Transform target)
    {
        Vector3 direction = (target.position + target.up - _shootPoint[_currentBarrelIndex].position).normalized;
        Quaternion rotation = Quaternion.LookRotation(direction);
        Bullet newBullet = Instantiate(_bulletTemplate, _shootPoint[_currentBarrelIndex].position, rotation);
        newBullet.Init(Damage);

        if (_shootFX != null)
            Instantiate(_shootFX, _shootPoint[_currentBarrelIndex].position, rotation);

        _currentBarrelIndex++;
        if (_currentBarrelIndex >= _shootPoint.Length)
            _currentBarrelIndex = 0;
    }
}