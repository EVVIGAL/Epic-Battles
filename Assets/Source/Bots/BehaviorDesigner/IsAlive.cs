using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class IsAlive : Conditional
{
    public MonoBehaviour HealthSource;

    private IHealth _health => (IHealth)HealthSource;

    public override TaskStatus OnUpdate()
    {
        if (_health.IsAlive)
            return TaskStatus.Success;

        return TaskStatus.Failure;
    }
}