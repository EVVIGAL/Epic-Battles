using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Remover : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private float _timerToRemove;

    private Camera _camera;
    private float _currentTimer;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _currentTimer = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _currentTimer += Time.unscaledDeltaTime;

            if (_currentTimer >= _timerToRemove)
            {
                RemoveUnit();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _currentTimer = 0;
        }

        if (Input.GetMouseButton(1))
            RemoveUnit();
    }

    private void RemoveUnit()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.GetComponentInParent<Unit>() == null)
                return;

            if (hit.collider.GetComponentInParent<Unit>().TryGetComponent(out Unit unit))
            {
                unit.Remove();
                _money.AddMoney(unit.Cost);
            }
        }
    }
}