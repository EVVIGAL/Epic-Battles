using System;
using UnityEngine;

[RequireComponent (typeof(Health))]
public class Bot : MonoBehaviour
{
    [field: SerializeField] public TypeOfTarget TypeOfTarget { get; private set; }
    [field: SerializeField] public TypeOfTarget AttackTarget { get; private set; }

    [field: SerializeField] public TypeOfArmy TypeOfArmy { get; private set; }
    [field: SerializeField] public TypeOfArmy PriorityAttackArmy { get; private set; }

    private Health _health;

    public bool IsAlive => _health.IsAlive;

    public Team Team { get; private set; }

    private void Awake()
    {
        _health = GetComponent<Health>();

        Team = transform.parent.GetComponent<Team>();
        if (Team == null)
            throw new InvalidOperationException("Team not found!");

        Team.AddBot(this);
    }

    private void OnDestroy()
    {
        Team.RemoveBot(this);
    }
}

public enum TypeOfTarget
{
    Ground,
    Air,
    All
}

public enum TypeOfArmy
{
    Soldier,
    Vehicle,
    All
}