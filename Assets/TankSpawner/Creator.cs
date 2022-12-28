using UnityEngine;
using UnityEngine.EventSystems;

public class Creator : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private Money _money;

    private Collider[] _colliders;
    private Vector3 _tankColliderSize;
    private Camera _camera;
    private int _groundLayer = 3;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (_unit != null && _money.Amount >= _unit.Cost)
                {
                    Vector3 position = GetPosition();

                    if (CheckSpawnPoint(position))
                        SpawnUnit(position);
                }
            }
        }
    }

    public void SetUnit(Unit unit)
    {
        _unit = unit;
        _tankColliderSize = _unit.GetComponent<Collider>().bounds.extents;
    }

    private void SpawnUnit(Vector3 position)
    {
        Instantiate(_unit, position, Quaternion.identity);
        _money.SpendMoney(_unit.Cost);
    }

    private Vector3 GetPosition()
    {
        Vector3 position;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            position = hit.point;
        else
            position = Vector3.zero;

        return position;
    }

    private bool CheckSpawnPoint(Vector3 position)
    {
        _colliders = Physics.OverlapBox(position, _tankColliderSize, Quaternion.identity, _groundLayer);

        if (_colliders.Length > 0)
            return false;
        else
            return true;
    }
}