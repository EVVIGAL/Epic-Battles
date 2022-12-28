using UnityEngine;

public class Bullet<SelfTeam> : MonoBehaviour
{
    [SerializeField] private uint _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out SelfTeam self))
            return;

        if (collision.gameObject.TryGetComponent(out IHealth health))
        {
            if (health.IsAlive)
            {
                health.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}