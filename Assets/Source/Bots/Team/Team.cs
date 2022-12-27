using System;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField] private List<Transform> _units = new();

    private void Awake()
    {
        foreach (Transform child in transform)
            _units.Add(child);
    }

    public void Remove(Transform transform)
    {
        if (_units.Contains(transform) == false)
            throw new InvalidOperationException();

        _units.Remove(transform);
    }

    public Transform GetNearbyObject(Vector3 position)
    {
        Transform nearbyObject = null;
        float nearbyObjectDistance = float.PositiveInfinity;
        for (int i = 0; i < _units.Count; i++)
        {
            float distance = (position - _units[i].position).sqrMagnitude;
            if (distance < nearbyObjectDistance)
            {
                nearbyObject = _units[i];
                nearbyObjectDistance = distance;
            }
        }

        return nearbyObject;
    }
}