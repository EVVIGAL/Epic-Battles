using System;
using System.Collections.Generic;
using UnityEngine;

public class GetObjectsInRadius<TObject>
{
    private float _radius;
    private Transform _center;

    private Collider[] _colliders = new Collider[50];
    private List<TObject> _objects = new List<TObject>();

    public GetObjectsInRadius(float radius, Transform center)
    {
        _radius = radius;
        _center = center ?? throw new ArgumentNullException(nameof(center));
    }

    public IEnumerable<TObject> Get()
    {
        Physics.OverlapSphereNonAlloc(_center.position, _radius, _colliders);
        int count = Physics.OverlapSphereNonAlloc(_center.position, _radius, _colliders);
        for (int i = 0; i < count; i++)
        {
            Collider collider = _colliders[i];
            if (collider.transform == _center)
                continue;

            if (collider.TryGetComponent(out TObject detectedObject))
                _objects.Add(detectedObject);
        }

        return _objects;
    }
}