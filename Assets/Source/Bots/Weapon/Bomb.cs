using System.Collections;
using UnityEngine;

public class Bomb : Projectile
{
    [SerializeField] private float _radius;

    protected override void OnHit(RaycastHit hitInfo)
    {
        base.OnHit(hitInfo);

        var units = new GetObjectsInRadius<IHealth>(_radius, transform);
        IEnumerable healths = units.Get();
        foreach (IHealth health in healths)
            if (health.IsAlive)
                health.TakeDamage(Damage);
    }
}