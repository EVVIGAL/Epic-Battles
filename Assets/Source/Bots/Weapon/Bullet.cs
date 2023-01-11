using UnityEngine;

public class Bullet<SelfTeam> : MonoBehaviour
{
    [SerializeField] private uint _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _raycastDistance = 1f;
    [SerializeField] private ParticleSystem _hitFX;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _raycastDistance))
        {
            if (hitInfo.transform.TryGetComponent(out IHealth health))
            {
                if (health.IsAlive)
                {
                    health.TakeDamage(_damage);
                    Destroy(gameObject);

                    if (_hitFX != null)
                        Instantiate(_hitFX, hitInfo.point, Quaternion.identity);
                }
            }

            if (hitInfo.rigidbody != null)
                hitInfo.rigidbody.AddForce(transform.forward * _pushForce, ForceMode.Impulse);
        }
    }
}