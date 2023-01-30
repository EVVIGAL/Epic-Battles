using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Money _money;
    [SerializeField] private Team _alliedTeam;
    [SerializeField] private Team _enemyTeam;
    [SerializeField] private Quaternion _rotation;
    [SerializeField] private LayerMask _layerMask;

    private Vector3 _tankColliderSize;
    private Vector3 _helicopterSize = new(3f, 3f, 3f);
    private Vector3 _tankSize = new(3f, 3f, 3f);
    private Vector3 _soldierSize = new(1f, 1f, 1f);
    private Collider[] _colliders;
    private Camera _camera;
    private Unit _unit;
    private float _helicopterHeight = 10f;
    private string _boundNameStr = "Bounds";
    private string _soldierTxt = "Soldier";
    private string _helicopterTxt = "Helicopter";

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (_unit != null && _money.Amount >= _unit.Cost)
            {
                Vector3 position = GetPosition();

                if (position == Vector3.zero)
                    return;

                if (_unit.Name == _helicopterTxt)
                    position.y = _helicopterHeight;

                if (CheckSpawnPoint(position))
                    SpawnUnit(position);
            }
        }
    }

    public void SetUnit(Unit unit)
    {
        _unit = unit;

        if (_unit.Name == _soldierTxt)
            _tankColliderSize = _soldierSize;
        else if (_unit.Name == _helicopterTxt)
            _tankColliderSize = _helicopterSize;
        else
            _tankColliderSize = _tankSize;
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
            {
                position = hit.point;
            }
            else if (hit.collider.TryGetComponent(out Unit unit))
            {
                if (_unit.Name == _helicopterTxt && unit.Name != _helicopterTxt)
                {
                    position = hit.point;
                    position.y = 0f;
                }
            }
        }
        else
        {
            position = Vector3.zero;
        }

        return position;
    }

    private bool CheckSpawnPoint(Vector3 position)
    {
        _colliders = Physics.OverlapBox(position, _tankColliderSize, Quaternion.identity, _layerMask);
        return !(_colliders.Length > 0);
    }
}