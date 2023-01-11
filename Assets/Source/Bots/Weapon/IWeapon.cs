using UnityEngine;

public interface IWeapon
{
    bool CanShoot { get; }
    void Shoot(Transform target);
}