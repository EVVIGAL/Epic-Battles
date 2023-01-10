using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UnitChoser : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Unit _unit;

    private Button _button;
    private TextMeshProUGUI _text;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetUnit);
        _text.text = $"{_unit.Cost}";
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void SetUnit()
    {
        _spawner.SetUnit(_unit);
    }
}