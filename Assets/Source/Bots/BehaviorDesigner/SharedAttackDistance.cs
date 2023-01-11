using BehaviorDesigner.Runtime;
using System;

[Serializable]
public class SharedAttackDistance : SharedVariable<AttackDistance>
{
    public static implicit operator SharedAttackDistance(AttackDistance value) => new SharedAttackDistance { Value = value };
}