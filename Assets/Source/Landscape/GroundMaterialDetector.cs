using UnityEngine;

public class GroundMaterialDetector : MonoBehaviour, IGroundMaterialDetector
{
    private const float DefaultFriction = 1f;

    private float _currentFriction;

    public float Friction => _currentFriction;

    private void Awake()
    {
        _currentFriction = DefaultFriction;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out GroundMaterial groundMaterial))
            _currentFriction = groundMaterial.Friction;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out GroundMaterial groundMaterial))
            _currentFriction = DefaultFriction;
    }
}