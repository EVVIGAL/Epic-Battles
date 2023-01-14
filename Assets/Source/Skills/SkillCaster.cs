using UnityEngine.EventSystems;
using UnityEngine;

public class SkillCaster : MonoBehaviour
{
    [SerializeField] private Skill[] _skills;
    [SerializeField] private Camera _camera;
    [SerializeField] private int _artHeight;
    [SerializeField] private int _smokeHeight;

    private Skill _currentSkill;
    private bool _isReady;
    private int _artIndex = 0;
    private int _smokeIndex = 1;

    public bool IsReady => _isReady;

    private void Awake()
    {
        _isReady = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                if (_isReady)
                {
                    SpawnSkill(GetPosition());
                    _isReady = false;
                }
            }
        }
    }
    public void Activate(int index)
    {
        _isReady = true;
        _currentSkill = _skills[index];
    }

    private Vector3 GetPosition()
    {
        Vector3 position = Vector3.zero;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            position = hit.point;
        else
            position = Vector3.zero;

        if (_currentSkill == _skills[_artIndex])
            position.y = _artHeight;

        if (_currentSkill == _skills[_smokeIndex])
            position.y = _smokeHeight;

        return position;
    }

    private void SpawnSkill(Vector3 position)
    {
        Instantiate(_currentSkill, position, Quaternion.identity);
    }
}