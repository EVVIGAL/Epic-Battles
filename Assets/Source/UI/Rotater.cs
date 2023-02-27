using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;

    private void Update()
    {
        transform.eulerAngles = _rotation;
    }
}