using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private Team _alliedTeam;
    [SerializeField] private Team _enemyTeam;
    [SerializeField] private Quaternion _rotation;

    private Vector3 _tankColliderSize;
    private Collider[] _colliders;
    private Camera _camera;
    private Unit _unit;
    private int _groundLayer = 3;
    private string _boundNameStr = "Bounds";

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

                    if (position == Vector3.zero)
                        return;

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
        Instantiate(_unit, position, _rotation, _alliedTeam.transform);
        _money.SpendMoney(_unit.Cost);
    }

    private Vector3 GetPosition()
    {
        Vector3 position = Vector3.zero;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.name == _boundNameStr)
                position = hit.point;
        }
        else
        {
            position = Vector3.zero;
        }

        return position;
    }

    private bool CheckSpawnPoint(Vector3 position)
    {
        _colliders = Physics.OverlapBox(position, _tankColliderSize, Quaternion.identity, _groundLayer);
        return !(_colliders.Length > 0);
    }
}