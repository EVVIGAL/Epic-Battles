using UnityEngine;

public class MultiBarreledGun : DefaultGun
{
    [SerializeField] private Transform[] _shootPoint;

    private int _currentBarrelIndex;

    protected override Vector3 GetShootPoint()
    {
        _currentBarrelIndex++;
        if (_currentBarrelIndex >= _shootPoint.Length)
            _currentBarrelIndex = 0;

        return _shootPoint[_currentBarrelIndex].position;
    }
}