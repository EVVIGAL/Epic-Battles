using System;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [field: SerializeField] public Team EnemyTeam { get; private set; }

    private List<Bot> _bots = new();

    private void Awake()
    {
        foreach (Transform child in transform)
            if (child.TryGetComponent(out Bot bot))
                _bots.Add(bot);
    }

    public void AddBot(Bot bot)
    {
        if (_bots.Contains(bot))
            throw new InvalidOperationException(bot.name + " already contained in " + gameObject.name);

        _bots.Add(bot);
    }

    public Transform GetNearbyBot(Vector3 position)
    {
        Transform nearbyObject = null;
        float nearbyObjectDistance = float.PositiveInfinity;
        for (int i = 0; i < _bots.Count; i++)
        {
            if (_bots[i].IsAlive == false)
                continue;

            float distance = (position - _bots[i].transform.position).sqrMagnitude;
            if (distance < nearbyObjectDistance)
            {
                nearbyObject = _bots[i].transform;
                nearbyObjectDistance = distance;
            }
        }

        return nearbyObject;
    }
}