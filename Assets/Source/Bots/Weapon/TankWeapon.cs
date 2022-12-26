using UnityEngine;

public class TankWeapon : Weapon
{
    [SerializeField] private Bullet _bulletTemplate;
    [SerializeField] private Transform _shootPoint;

    protected override void OnShoot()
    {
        Instantiate(_bulletTemplate, _shootPoint.position, Quaternion.LookRotation(_shootPoint.forward));
    }
}