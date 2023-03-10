using System;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour
{
    [field: SerializeField] public Team EnemyTeam { get; private set; }
    [field: SerializeField] public Material Material { get; private set; }

    private List<Bot> _bots = new();

    private Transform _nearbyObject;
    private float _nearbyObjectDistance;

    public bool IsAlive => _bots.Find(bot => bot.IsAlive);

    public void AddBot(Bot bot)
    {
        if (_bots.Contains(bot))
            throw new InvalidOperationException(bot.name + " already contained in " + gameObject.name);

        _bots.Add(bot);
    }

    public void RemoveBot(Bot bot)
    {
        if (_bots.Contains(bot) == false)
            throw new InvalidOperationException();

        _bots.Remove(bot);
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

    public Transform GetNearbyBot(Bot bot)
    {
        _nearbyObject = null;
        _nearbyObjectDistance = float.PositiveInfinity;
        bool isPriorityObject = false;

        for (int i = 0; i < _bots.Count; i++)
        {
            if (_bots[i].IsAlive == false)
                continue;

            if (bot.AttackTarget != TypeOfTarget.All && bot.AttackTarget != _bots[i].TypeOfTarget)
                continue;

            float distance = (bot.transform.position - _bots[i].transform.position).sqrMagnitude;

            if (distance < _nearbyObjectDistance)
            {
                if (bot.PriorityAttackArmy == TypeOfArmy.All || bot.PriorityAttackArmy == _bots[i].TypeOfArmy)
                {
                    SetNearbyBot(_bots[i].transform, distance);
                    isPriorityObject = true;
                }
                else if (isPriorityObject == false)
                {
                    SetNearbyBot(_bots[i].transform, distance);
                }
            }
            else
            {
                if (bot.PriorityAttackArmy == _bots[i].TypeOfArmy && isPriorityObject == false)
                    SetNearbyBot(_bots[i].transform, distance);
            }
        }

        return _nearbyObject;
    }

    private void SetNearbyBot(Transform bot, float distance)
    {
        _nearbyObject = bot;
        _nearbyObjectDistance = distance;
    }
}