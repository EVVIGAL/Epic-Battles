using System;
using System.Collections;
using UnityEngine;

[RequireComponent (typeof(Rigidbody), typeof(Collider))]
public class TurelExplosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier = 1f;
    [SerializeField] private ParticleSystem _explosionFX;

    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void Explose()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
        Vector2 randomOffset = UnityEngine.Random.insideUnitCircle.normalized;
        Vector3 explosionPosition = transform.position + new Vector3(randomOffset.x, -1f, randomOffset.y) * _radius / 2f;
        _rigidbody.AddExplosionForce(_force, explosionPosition, _radius, _upwardsModifier, ForceMode.Impulse);
        StartCoroutine(Wait(() => _collider.enabled = false));

        if (_explosionFX != null)
            Instantiate(_explosionFX, transform.position, Quaternion.identity);
    }

    private IEnumerator Wait(Action endCallback)
    {
        yield return new WaitForSeconds(3f);
        endCallback?.Invoke();
    }
}