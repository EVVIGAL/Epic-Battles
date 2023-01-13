using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class SkillCaster : MonoBehaviour
{
    [SerializeField] private Skill[] _skills;
    [SerializeField] private Camera _camera;
    [SerializeField] private Button _artButton;
    [SerializeField] private Button _smokeButton;
    [SerializeField] private int _height;

    private Skill _currentSkill;
    private int _artIndex = 0;
    private int _smokeIndex = 1;

    private void Awake()
    {
        _artButton.onClick.AddListener(() => SetSkill(_artIndex));
        _smokeButton.onClick.AddListener(() => SetSkill(_smokeIndex));
    }

    private void OnDisable()
    {
        _artButton.onClick.RemoveAllListeners();
        _smokeButton.onClick.RemoveAllListeners();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                SpawnSkill(GetPosition());
                //enabled = false;
            }
        }
    }

    private Vector3 GetPosition()
    {
        Vector3 position = Vector3.zero;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
            position = hit.point;
        else
            position = Vector3.zero;

        if(_currentSkill == _skills[0])
            position.y = _height;
        else
            position.y = 5;

        return position;
    }

    private void SpawnSkill(Vector3 position)
    {
        Instantiate(_currentSkill, position, Quaternion.identity);
    }

    public void SetSkill(int index)
    {
        _currentSkill= _skills[index];
    }
}