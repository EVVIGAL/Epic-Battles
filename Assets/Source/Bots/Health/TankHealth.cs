using UnityEngine;

public class TankHealth : Health
{
    [SerializeField] private TurelExplosion _turelExplosion;

    protected override void Die()
    {
        _turelExplosion.Explose();
    }
}