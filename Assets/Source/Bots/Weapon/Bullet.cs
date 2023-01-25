using UnityEngine;

public class Bullet : Shell
{
    protected override void OnHit(RaycastHit hitInfo)
    {
        if (hitInfo.transform.TryGetComponent(out IHealth health))
        {
            int securityValue = 0;
            if (hitInfo.transform.TryGetComponent(out Security security))
                securityValue = security.Value;
            int hitChance = Random.Range(0, 100);

            if (health.IsAlive && hitChance >= securityValue)
                health.TakeDamage(Damage);
        }

        base.OnHit(hitInfo);
    }
}