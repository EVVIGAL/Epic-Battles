using System.Collections;
using UnityEngine;

public class ArtBlow : MonoBehaviour
{
    [field: SerializeField] public uint Damage { get; private set; }
    [SerializeField] private Bomb _bulletTemplate;
    [SerializeField] private float _radius;
    [SerializeField] private float _shootCount;
    [SerializeField] private float _rateOfFire;

    private IEnumerator Start()
    {
        int _currentShootCount = 0;
        while(_currentShootCount < _shootCount)
        {
            Vector2 positionOffset = Random.insideUnitCircle;
            positionOffset *= _radius;
            Bomb newBomb = Instantiate(_bulletTemplate, transform.position + new Vector3(positionOffset.x, 0f, positionOffset.y), Quaternion.LookRotation(Vector3.down));
            newBomb.Init(Damage);

            _currentShootCount++;
            yield return new WaitForSeconds(_rateOfFire);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, 0f, transform.position.z), _radius);
    }
}