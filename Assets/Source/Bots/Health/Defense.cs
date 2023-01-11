using UnityEngine;

public class Defense : MonoBehaviour
{
    [SerializeField] private float _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Stealthiness stealthiness))
            stealthiness.Add(_value);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Stealthiness stealthiness))
            stealthiness.Remove();
    }
}