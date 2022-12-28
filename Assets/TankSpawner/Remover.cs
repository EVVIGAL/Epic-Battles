using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    [SerializeField] private float _timerToRemove;
    [SerializeField] private Money _money;

    private Camera _camera;
    private float _currentTimer;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _currentTimer = 0;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _currentTimer += Time.deltaTime;

            if(_currentTimer >= _timerToRemove)
            {
                Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                    if (hit.collider.TryGetComponent(out Unit unit))
                    {
                        unit.Remove();
                        _money.AddMoney(unit.Cost);
                    }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _currentTimer = 0;
        }
    }
}
