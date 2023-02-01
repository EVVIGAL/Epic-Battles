using UnityEngine;

public class EnemyActivator : MonoBehaviour
{
    [SerializeField] private Unit[] _unitsToActivate;
    [SerializeField] private float _waitUntilActivate;

    private float _elapsedTime;
    private bool _isActivated;

    private void Start()
    {
        if (_unitsToActivate.Length < 0)
            return;

        for (int i = 0; i < _unitsToActivate.Length; i++)
            _unitsToActivate[i].gameObject.SetActive(false);

        _isActivated = false;
    }

    private void Update()
    {
        if (_unitsToActivate.Length <= 0)
            return;

        if (_isActivated)
            return;

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _waitUntilActivate)
        {
            for (int i = 0; i < _unitsToActivate.Length; i++)
                _unitsToActivate[i].gameObject.SetActive(true);

            _isActivated = true;
        }
    }
}