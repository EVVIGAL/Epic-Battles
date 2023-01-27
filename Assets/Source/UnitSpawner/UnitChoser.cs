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
    private InfoPanel _infoPanel;
    private Button _button;

    public event UnityAction OnUnitSet;

    public Unit Unit => _unit;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _text = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        _infoPanel = GetComponentInChildren<InfoPanel>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(SetUnit);
        _text.text = $"{_unit.Cost}";
        _image.overrideSprite = _unit.Sprite;
        _image.preserveAspect = true;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SetUnit);
    }

    private void SetUnit()
    {
        _spawner.SetUnit(_unit);
        OnUnitSet?.Invoke();
        _infoPanel.Activate();
        GetComponent<Image>().color = Color.white;
    }
}