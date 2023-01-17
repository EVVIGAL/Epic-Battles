using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UnitChoser : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Unit _unit;
    [SerializeField] private Image _image;
    [SerializeField] private Image[] _allButtons;

    private TextMeshProUGUI _text;
    private Button _button;

    public event UnityAction<Unit> OnUnitSet;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetUnit);
        _text.text = $"{_unit.Name}\n{_unit.Cost}";
        _image.overrideSprite = _unit.Sprite;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void SetUnit()
    {
        _spawner.SetUnit(_unit);
        OnUnitSet?.Invoke(_unit);
        GetComponent<Image>().color = Color.blue;
    }
}