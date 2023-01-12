using UnityEngine;

public class Defense : MonoBehaviour
{
    [SerializeField] private int _value = 50;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Security stealthiness))
            stealthiness.Add(_value);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Security stealthiness))
            stealthiness.Remove();
    }
}