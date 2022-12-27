using UnityEngine;

public class DamageReceiver : MonoBehaviour, IHealth
{
    [SerializeField] private MonoBehaviour _healthSource;
    private IHealth _health => (IHealth)_healthSource;

    public bool IsAlive => _health.IsAlive;

    public void TakeDamage(uint damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnValidate()
    {
        if (_healthSource && !(_healthSource is IHealth))
        {
            Debug.LogError(nameof(_healthSource) + " is not implement " + nameof(IHealth));
            _healthSource = null;
        }
    }
}