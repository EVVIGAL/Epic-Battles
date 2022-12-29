using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject _blueTeam;
    [SerializeField] private GameObject _redTeam;

    private Slider _slider;
    private List<GameObject> _allies;
    private List<GameObject> _enemies;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void Start()
    {
        InitTeam(_allies, _blueTeam);
        InitTeam(_enemies, _redTeam);
    }

    private void Update()
    {
        SetSliderValue();
    }

    public void SetSliderValue()
    {
        float bluePower = GetPower(_allies);
        float redPower = GetPower(_enemies);
        _slider.value = bluePower / (bluePower + redPower);
    }

    private float GetPower(List<GameObject> team)
    {
        float power = 0;

        foreach (GameObject unit in team)
        {
            Unit unit2 = unit.GetComponent<Unit>();
            power += unit2.Cost;
        }

        return power;
    }

    private void InitTeam(List<GameObject> teamList, GameObject team)
    {
        for (int i = 0; i < team.transform.childCount; i++)
        {
            if (team.transform.GetChild(i).TryGetComponent(out Unit unit))
            {
                teamList.Add(team.transform.GetChild(i).gameObject);
            }
        }
    }
}