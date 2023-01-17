using System.Collections.Generic;
using UnityEngine;

public class UnitsObserver : MonoBehaviour
{
    [SerializeField] private EndBattle _end;
    [SerializeField] private GameObject _red;
    [SerializeField] private GameObject _blue;
    [SerializeField] private List<Health> _redTeam;
    [SerializeField] private List<Health> _blueTeam;

    private SkillsController _skillController;

    private void Awake()
    {
        _skillController = GetComponent<SkillsController>();
    }

    private void OnDisable()
    {
        foreach (Health unit in _redTeam)
            unit.Died -= CheckTeam;

        foreach (Health unit in _blueTeam)
            unit.Died -= CheckTeam;
    }

    public bool TryStart()
    {
        return _blue.transform.childCount > 0;
    }

    public void Init()
    {
        InitTeam(_red, _redTeam);
        InitTeam(_blue, _blueTeam);
    }

    public bool CheckForUnit(Unit neededUnit)
    {
        if (_blueTeam.Count <= 0)
            return false;

        foreach (Health health in _blueTeam)
        {
            Unit unit = health.GetComponent<Unit>();

            if (unit.Name == neededUnit.Name && health.Value > 0)
                return true;
        }

        return false;
    }

    private void InitTeam(GameObject team, List<Health> list)
    {
        for (int i = 0; i < team.transform.childCount; i++)
        {
            if (team.transform.GetChild(i).TryGetComponent(out Health unit))
            {
                list.Add(unit);
                unit.Died += CheckTeam;
            }
        }
    }

    private void CheckTeam()
    {
        _skillController.CheckUnits();
        bool redDefeated = true;
        bool blueDefeated = true;

        foreach (Health unit in _redTeam)
        {
            if (unit.Value > 0)
            {
                redDefeated = false;
                break;
            }
        }

        foreach (Health unit in _blueTeam)
        {
            if (unit.Value > 0)
            {
                blueDefeated = false;
                break;
            }
        }

        if (redDefeated)
        {
            _end.gameObject.SetActive(true);
            _end.SetPanelInfo(redDefeated);
        }

        if (blueDefeated)
        {           
            _end.gameObject.SetActive(true);
            _end.SetPanelInfo(!blueDefeated);
        }
    }
}