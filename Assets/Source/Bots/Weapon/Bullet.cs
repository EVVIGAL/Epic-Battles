using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public uint _damage;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}