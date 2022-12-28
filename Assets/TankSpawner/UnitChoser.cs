using UnityEngine;
using UnityEngine.UI;

public class UnitChoser : MonoBehaviour
{
    [SerializeField] private Creator _creator;
    [SerializeField] private Unit _unit;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetUnit);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void SetUnit()
    {
        _creator.SetUnit(_unit);
    }
}
