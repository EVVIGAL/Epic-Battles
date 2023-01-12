using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    [field: SerializeField] public uint MaxValue { get; private set; }

    [SerializeField] private MonoBehaviour _deathSource;
    private IDeath _death => (IDeath)_deathSource;

    public uint Value { get; private set; }

    public bool IsAlive => Value > 0;

    public event Action Died;

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

    protected virtual void Die()
    {
        _death.Die();
        Died?.Invoke();
    }
}