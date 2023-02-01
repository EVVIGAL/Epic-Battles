using UnityEngine;

public class Projectile : MonoBehaviour, IProjectile
{
    [SerializeField] private float _speed;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _raycastDistance = 1f;
    [SerializeField] private float _liveTime;
    [SerializeField] private ParticleSystem _hitFX;

    private float _runningTime;

    public uint Damage { get; private set; }

    public bool IsActive => gameObject.activeSelf;

    private void Update()
    {
        _runningTime += Time.deltaTime;
        if (_runningTime >= _liveTime)
        {
            gameObject.SetActive(false);
            return;
        }

        transform.position += transform.forward * _speed * Time.deltaTime;

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, _raycastDistance))
            OnHit(hitInfo);
    }

    public void Init(uint damage, Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
        Damage = damage;
        _runningTime = 0f;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    protected virtual void OnHit(RaycastHit hitInfo)
    {
        if (_hitFX != null)
            Instantiate(_hitFX, hitInfo.point, Quaternion.identity);

        if (hitInfo.rigidbody != null)
            hitInfo.rigidbody.AddForce(transform.forward * _pushForce, ForceMode.Impulse);

        if (hitInfo.transform.TryGetComponent(out IObjectPhysics objectPhysics))
            if (objectPhysics.IsActive)
                objectPhysics.AddForce(transform.forward * _pushForce);

        gameObject.SetActive(false);
    }
}