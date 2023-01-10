using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private GameObject _blueTeam;
    [SerializeField] private GameObject _redTeam;

    private Slider _slider;
    private Animator _animator;
    private List<Unit> _allies;
    private List<Unit> _enemies;

    private string _animName = "ProgressBar";

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _animator = GetComponent<Animator>();
        _allies = new();
        _enemies = new();
    }

    private void OnEnable()
    {
        Refresh();
        _animator.Play(_animName);
    }

    public void Refresh()
    {
        InitTeam(_allies, _blueTeam);
        InitTeam(_enemies, _redTeam);
        SetSliderValue();
    }
    private void SetSliderValue()
    {
        float bluePower = GetPower(_allies);
        float redPower = GetPower(_enemies);
        _slider.value = bluePower / (bluePower + redPower);
    }

    private float GetPower(List<Unit> team)
    {
        float power = 0;

        foreach (Unit unit in team)
            power += unit.Cost;

        return power;
    }

    private void InitTeam(List<Unit> list, GameObject team)
    {
        foreach(Transform child in team.transform)
        {
            if (child.TryGetComponent(out Unit unit))
                list.Add(unit);
        }
    }
}