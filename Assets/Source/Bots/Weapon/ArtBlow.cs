using System.Collections;
using UnityEngine;

public class ArtBlow : DefaultGun
{
    [SerializeField] private float _radius;
    [SerializeField] private float _shootCount;

    private IEnumerator Start()
    {
        int _currentShootCount = 0;
        while(_currentShootCount < _shootCount)
        {
            if (CanShoot == false)
                yield return null;

            Shoot();
            _currentShootCount++;
            yield return new WaitForSeconds(RateOfFire);
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, 0f, transform.position.z), _radius);
    }

    protected override Vector3 GetShootPoint()
    {
        Vector2 positionOffset = Random.insideUnitCircle;
        positionOffset *= _radius;
        return transform.position + new Vector3(positionOffset.x, 0f, positionOffset.y);
    }

    protected override Quaternion GetRotation(Vector3 direction)
    {
        return base.GetRotation(Vector3.down);
    }
}