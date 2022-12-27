using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    [field: SerializeField] public uint MaxValue { get; private set; }
    
    public uint Value { get; private set; }

    public bool IsAlive => Value > 0;

    private void Awake()
    {
        Value = MaxValue;
    }

    public virtual void TakeDamage(uint damage)
    {
        if (IsAlive == false)
            throw new InvalidOperationException();

        Value = (uint)Math.Clamp((int)Value - damage, 0, MaxValue);

        if (Value == 0)
            Die();
    }

    protected abstract void Die();
}