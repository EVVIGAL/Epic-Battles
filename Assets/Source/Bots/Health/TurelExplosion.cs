using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class TurelExplosion : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _radius;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Explose()
    {
        _rigidbody.transform.parent = null;
        _rigidbody.isKinematic = false;
        _rigidbody.AddExplosionForce(_force, transform.position, _radius, 1f, ForceMode.Impulse);
    }
}