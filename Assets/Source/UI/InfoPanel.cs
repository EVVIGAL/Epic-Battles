using Lean.Localization;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject _skill;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _damageText;
    [SerializeField] private TextMeshProUGUI _skillText;
    [SerializeField] private Image _skillImage;
    [SerializeField] private RectTransform _rectTransform;

    private InfoPanel[] _infoPanels;
    private Unit _unit;

    private void Awake()
    {
        _infoPanels = GetComponentInParent<UnitsPanel>().GetComponentsInChildren<InfoPanel>();
        _unit = GetComponentInParent<UnitChoser>().Unit;
    }

    private void Start()
    {
        _nameText.text = LeanLocalization.GetTranslationText(_unit.Name);
        _healthText.text = _unit.GetComponent<Health>().MaxValue.ToString();
        _damageText.text = _unit.GetComponent<Weapon>().Damage.ToString();

        if (!string.IsNullOrEmpty(_unit.Skill))
        {
            string skillDescriptionTxt = LeanLocalization.GetTranslationText(_unit.Skill);
            _skillText.text = skillDescriptionTxt;
            LayoutRebuilder.ForceRebuildLayoutImmediate(_rectTransform);
        }
        else
        {
            _skill.SetActive(false);
        }

        if(_unit.SkillSprite != null)
            _skillImage.overrideSprite = _unit.SkillSprite;
        else
            _skill.SetActive(false);

        gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Time.timeScale > 0)
            gameObject.SetActive(false);
    }

    public void Activate()
    {
        for(int i = 0; i < _infoPanels.Length; i++)
            _infoPanels[i].gameObject.SetActive(false);

        gameObject.SetActive(true);
    }
}