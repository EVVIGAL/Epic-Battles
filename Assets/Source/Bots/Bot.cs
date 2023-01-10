using BehaviorDesigner.Runtime;
using System;
using UnityEngine;

[RequireComponent (typeof(BehaviorTree), typeof(Health))]
public class Bot : MonoBehaviour, IHealth
{
    private BehaviorTree _behaviorTree;
    private Health _health;
    private Team _team;

    private const string EnemyTeam = "_enemyTeam";

    public bool IsAlive => _health.IsAlive;

    private void Awake()
    {
        _behaviorTree = GetComponent<BehaviorTree>();
        _health = GetComponent<Health>();

        _team = transform.parent.GetComponent<Team>();
        if (_team == null)
            throw new InvalidOperationException("Team not found!");

        _team.AddBot(this);
        _behaviorTree.SetVariableValue(EnemyTeam, _team.EnemyTeam);
    }

    public void TakeDamage(uint damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnDestroy()
    {
        _team.RemoveBot(this);
    }
}