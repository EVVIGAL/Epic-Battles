using BehaviorDesigner.Runtime;
using System;

[Serializable]
public class SharedTeam : SharedVariable<Team>
{
    public static implicit operator SharedTeam(Team value) => new SharedTeam { Value = value };
}