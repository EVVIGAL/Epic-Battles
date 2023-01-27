using Lean.Localization;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _skillText;
    [SerializeField] private Image _skillImage;
    [SerializeField] private InfoPanel[] _infoPanels;

    private Unit _unit;

    private void Start()
    {
        _unit = GetComponentInParent<UnitChoser>().Unit;
        _nameText.text = _unit.Name;
        _healthText.text = _unit.GetComponent<Health>().MaxValue.ToString();
        _damageText.text = _unit.GetComponent<Weapon>().Damage.ToString();

        if (!string.IsNullOrEmpty(_unit.Skill))
        {
            string skillDescriptionTxt = LeanLocalization.GetTranslationText(_unit.Skill);
            _skillText.text = skillDescriptionTxt;
            Canvas.ForceUpdateCanvases();
        }
        else
        {
            _skillText.gameObject.SetActive(false);
        }

        if(_unit.SkillSprite != null)
            _skillImage.overrideSprite = _unit.SkillSprite;
        else
            _skillImage.gameObject.SetActive(false);

        gameObject.SetActive(false);
    }

    public void Activate()
    {
        for(int i = 0; i < _infoPanels.Length; i++)
            _infoPanels[i].gameObject.SetActive(false);

        gameObject.SetActive(true);
    }
}