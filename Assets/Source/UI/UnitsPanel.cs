using UnityEngine.UI;
using UnityEngine;

public class UnitsPanel : MonoBehaviour
{
    [SerializeField] private InfoPanel _infoPanel;

    private UnitChoser[] _allButtons;

    private void Awake()
    {
        _allButtons = GetComponentsInChildren<UnitChoser>();
    }

    private void OnEnable()
    {
        foreach (UnitChoser button in _allButtons)
            button.OnUnitSet += SetActiveUnit;
    }

    private void OnDisable()
    {
        foreach (UnitChoser button in _allButtons)
            button.OnUnitSet -= SetActiveUnit;
    }

    private void SetActiveUnit(Unit unit)
    {      
        ChangeButtonsColor();
        ShowInfo(unit);
    }

    private void ChangeButtonsColor()
    {
        foreach (UnitChoser button in _allButtons)
            button.GetComponent<Image>().color = Color.white;
    }

    private void ShowInfo(Unit unit)
    {
        _infoPanel.Activate(unit);
    }
}