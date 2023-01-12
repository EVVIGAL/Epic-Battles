using System.Collections;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    [SerializeField] private float _liveTime;

    private float _disappearanceSpeed = 3f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_liveTime);

        Destroy(gameObject, 5f);
        while (true)
        {
            transform.position += Vector3.down * _disappearanceSpeed * Time.deltaTime;
            yield return null;
        }
    }
}