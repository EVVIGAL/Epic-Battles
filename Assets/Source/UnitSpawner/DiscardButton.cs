using UnityEngine;
using UnityEngine.UI;

public class DiscardButton : MonoBehaviour
{
    [SerializeField] private GameObject _team;
    [SerializeField] private Money _money;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(RemoveAllUnits);   
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void RemoveAllUnits()
    {
        Unit[] allUnits = _team.GetComponentsInChildren<Unit>();

        foreach (Unit unit in allUnits)
        {
            _money.AddMoney(unit.Cost);
            Destroy(unit.gameObject);
        }
    }
}