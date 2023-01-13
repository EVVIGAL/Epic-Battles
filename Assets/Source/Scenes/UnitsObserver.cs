using System.Collections.Generic;
using UnityEngine;

public class UnitsObserver : MonoBehaviour
{
    [SerializeField] private EndBattle _end;
    [SerializeField] private GameObject _red;
    [SerializeField] private GameObject _blue;
    [SerializeField] private List<Unit> _redTeam;
    [SerializeField] private List<Unit> _blueTeam;

    private void OnDisable()
    {
        foreach (Unit unit in _redTeam)
            unit.IsDestroyed -= CheckTeam;

        foreach (Unit unit in _blueTeam)
            unit.IsDestroyed -= CheckTeam;
    }

    public void Init()
    {
        InitTeam(_red, _redTeam);
        InitTeam(_blue, _blueTeam);
    }

    private void InitTeam(GameObject team, List<Unit> list)
    {
        for (int i = 0; i < team.transform.childCount; i++)
        {
            if (team.transform.GetChild(i).TryGetComponent(out Unit unit))
            {
                list.Add(unit);
                unit.IsDestroyed += CheckTeam;
            }
        }
    }

    private void CheckTeam()
    {       
        bool redDefeated = true;
        bool blueDefeated = true;

        foreach (Unit unit in _redTeam)
        {
            if (unit.enabled)
                redDefeated = false;
        }

        foreach (Unit unit in _blueTeam)
        {
            if (unit.enabled)
                blueDefeated = false;
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