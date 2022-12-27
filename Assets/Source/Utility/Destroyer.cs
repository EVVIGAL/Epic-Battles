using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float _liveTime = 2f;

    private void Start()
    {
        Destroy(gameObject, _liveTime);
    }
}