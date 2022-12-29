using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [SerializeField] private Team _enemyTeam;

    private List<Bot> _bots = new();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Bot bot))
            {
                bot.Init(_enemyTeam);
                _bots.Add(bot);
            }
        }
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

    public void AddBot()
    {
        _bots.Clear();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out Bot bot))
            {
                bot.Init(_enemyTeam);
                _bots.Add(bot);
            }
        }
    }
}