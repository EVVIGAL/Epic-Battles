using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsController : MonoBehaviour
{
    [SerializeField] private SkillButton _artButton;
    [SerializeField] private SkillButton _smokeButton;
    [SerializeField] private Unit _artUnit;
    [SerializeField] private Unit _smokeUnit;
    [SerializeField] private int _artCount;
    [SerializeField] private int _smokeCount;

    private UnitsObserver _observer;

    private void Awake()
    {
        _observer = GetComponent<UnitsObserver>();
    }

    private void OnEnable()
    {
        _artButton.OnActivateSkill += DecreaseArt;
        _smokeButton.OnActivateSkill += DecreaseSmoke;
    }

    private void OnDisable()
    {
        _artButton.OnActivateSkill -= DecreaseArt;
        _smokeButton.OnActivateSkill -= DecreaseSmoke;
    }

    public void CheckUnits()
    {
        if(!_observer.CheckForUnit(_artUnit) || _artCount <= 0)
            _artButton.Deactivate(_artCount);
        else
            _artButton.Activate();

        if (!_observer.CheckForUnit(_smokeUnit) || _smokeCount <= 0)
            _smokeButton.Deactivate(_smokeCount);
        else
            _smokeButton.Activate();
    }

    private void DecreaseArt()
    {
        _artCount--;

        if (_artCount <= 0)
            _artButton.Deactivate(_artCount);
    }

    private void DecreaseSmoke()
    {
        _smokeCount--;

        if (_smokeCount <= 0)
            _smokeButton.Deactivate(_smokeCount);
    }
}