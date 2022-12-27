using UnityEngine;

public class TankHealth : Health
{
    [SerializeField] private TurelExplosion _turelExplosion;
    [SerializeField] private Team _team;

    protected override void Die()
    {
        _turelExplosion.Explose();
        _team.Remove(transform);
    }
}