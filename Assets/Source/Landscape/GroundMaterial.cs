using UnityEngine;

public class GroundMaterial : MonoBehaviour, IGroundMaterial
{
    private const float DefaultFriction = 0.8f;

    private float _currentFriction;

    public float Friction => _currentFriction;

    private void Awake()
    {
        _currentFriction = DefaultFriction;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.sharedMaterial != null)
            _currentFriction = collision.collider.sharedMaterial.staticFriction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.sharedMaterial != null)
            _currentFriction = other.sharedMaterial.staticFriction;
    }

    private void OnTriggerExit(Collider other)
    {
        _currentFriction = DefaultFriction;
    }
}