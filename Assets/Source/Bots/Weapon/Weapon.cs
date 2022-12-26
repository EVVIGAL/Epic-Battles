using System;
using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private float _rateOfFire;
    [SerializeField] private float _reloadSpeed;
    [SerializeField] private uint _magazineSize;

    public bool CanShoot => IsEmpty == false && _isReloading == false;

    public bool IsEmpty => _ammoInMagazine == 0;

    private uint _ammoInMagazine;
    private bool _isReloading;

    private void Awake()
    {
        _ammoInMagazine = _magazineSize;
    }

    public virtual void Shoot()
    {
        if (CanShoot == false)
            throw new InvalidOperationException();

        OnShoot();
        _isReloading = true;
        _ammoInMagazine--;

        if (IsEmpty)
        {
            OnReload();
            StartCoroutine(Wait(_reloadSpeed, () =>
            {
                _ammoInMagazine = _magazineSize;
                _isReloading = false;
            }));
            return;
        }

        StartCoroutine(Wait(_rateOfFire, () => _isReloading = false));
    }

    protected virtual void OnShoot() { }

    protected virtual void OnReload() { }

    private IEnumerator Wait(float time, Action onSuccessCallback)
    {
        yield return new WaitForSeconds(time);
        onSuccessCallback?.Invoke();
    }
}