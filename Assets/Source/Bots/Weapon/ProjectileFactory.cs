using System;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour, IProjectileFactory
{
    [SerializeField] private Projectile _projectile;
    [SerializeField] private uint _poolCapacity = 1;

    private IProjectile[] _bullets;

    private void Awake()
    {
        _bullets = new Projectile[_poolCapacity];

        for (int i = 0; i < _poolCapacity; i++)
        {
            Projectile newBullet = Instantiate(_projectile);
            newBullet.gameObject.SetActive(false);
            _bullets[i] = newBullet;
        }
    }

    public IProjectile Create()
    {
        IProjectile projectile = Array.Find(_bullets, bullet => bullet.IsActive == false);
        if (projectile != null)
            projectile.Enable();

        return projectile;
    }
}