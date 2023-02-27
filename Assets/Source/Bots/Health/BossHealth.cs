using UnityEngine;

public class BossHealth : TankHealth
{
    [SerializeField] private HealthBar _healthBar;

    public override void TakeDamage(uint damage)
    {
        base.TakeDamage(damage);
        _healthBar.Show(Value, MaxValue);
    }
}