using UnityEngine;

public class TankHealth : Health
{
    [SerializeField] private TurelExplosion _turelExplosion;

    protected override void Die()
    {
        base.Die();
        _turelExplosion.Explose();
    }
}