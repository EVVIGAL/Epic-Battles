using BehaviorDesigner.Runtime;
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
    }

    public void Init(Team team)
    {
        _behaviorTree.SetVariableValue(EnemyTeam, team);
    }

    public void TakeDamage(uint damage)
    {
        _health.TakeDamage(damage);
    }
}