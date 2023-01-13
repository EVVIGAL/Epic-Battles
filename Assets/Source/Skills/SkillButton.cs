using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private SkillCaster _caster;
    [SerializeField] private int _skillIndex;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ActivateSkill);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void ActivateSkill()
    {
        _caster.enabled = true;
    }
}
