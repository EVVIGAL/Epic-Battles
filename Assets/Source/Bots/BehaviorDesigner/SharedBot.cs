using BehaviorDesigner.Runtime;
using System;

[Serializable]
public class SharedBot : SharedVariable<Bot>
{
    public static implicit operator SharedBot(Bot value) => new SharedBot { Value = value };
}