using System.Collections.Generic;
using UnityEngine;

public class UnitsObserver : MonoBehaviour
{
    [SerializeField] private EndBattle _failPanel;
    [SerializeField] private EndBattle _winPanel;
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
            Unit unit = null;

            if (health.Value > 0)
                unit = health.GetComponent<Unit>();
            
            if(unit != null)
            {
                if (unit.Name == neededUnit.Name)
                    return true;
            }
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
            if (_failPanel.gameObject.activeSelf)
                return;

            _winPanel.gameObject.SetActive(true);
        }

        if (blueDefeated)
        {
            if (_winPanel.gameObject.activeSelf)
                return;

            _failPanel.gameObject.SetActive(true);
        }      
    }
}