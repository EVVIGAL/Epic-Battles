using BehaviorDesigner.Runtime;
using System;
using UnityEngine;

[RequireComponent (typeof(BehaviorTree), typeof(Health))]
public class Bot : MonoBehaviour, IHealth
{
    private BehaviorTree _behaviorTree;
    private Health _health;

    private const string EnemyTeam = "_enemyTeam";

    public bool IsAlive => _health.IsAlive;

    private void Awake()
    {
        _behaviorTree = GetComponent<BehaviorTree>();
        _health = GetComponent<Health>();
        
        Team team = transform.parent.GetComponent<Team>();
        if (team == null)
            throw new InvalidOperationException("Team not found!");

        team.AddBot(this);
        _behaviorTree.SetVariableValue(EnemyTeam, team.EnemyTeam);
    }

    public void TakeDamage(uint damage)
    {
        _health.TakeDamage(damage);
    }
}