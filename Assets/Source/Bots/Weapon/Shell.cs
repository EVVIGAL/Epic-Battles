using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _raycastDistance = 1f;
    [SerializeField] private ParticleSystem _hitFX;

    public uint Damage { get; private set; }

    public void Init(uint damage)
    {
        Damage = damage;
    }

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _raycastDistance))
            OnHit(hitInfo);
    }

    protected virtual void OnHit(RaycastHit hitInfo)
    {
        Destroy(gameObject);

        if (_hitFX != null)
            Instantiate(_hitFX, hitInfo.point, Quaternion.identity);

        if (hitInfo.rigidbody != null)
            hitInfo.rigidbody.AddForce(transform.forward * _pushForce, ForceMode.Impulse);

        if (hitInfo.transform.TryGetComponent(out IObjectPhysics objectPhysics))
            if (objectPhysics.IsActive)
                objectPhysics.AddForce(transform.forward * _pushForce);
    }
}