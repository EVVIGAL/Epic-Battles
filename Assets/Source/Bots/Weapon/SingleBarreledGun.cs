using UnityEngine;

public class SingleBarreledGun : DefaultGun
{
    [SerializeField] private Transform _shootPoint;

    protected override Vector3 GetShootPoint()
    {
        return _shootPoint.position;
    }
}