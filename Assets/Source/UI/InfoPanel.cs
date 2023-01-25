using Lean.Localization;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Image _image;

    private TextMeshProUGUI _text;
    private string _healthKey = "Health";
    private string _skillKey = "Skill";

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Activate(Unit unit)
    {
        string healthTxt = LeanLocalization.GetTranslationText(_healthKey);
        string skillTxt = LeanLocalization.GetTranslationText(_skillKey);
        string nameTxt = LeanLocalization.GetTranslationText(unit.Name);
        string skillDescriptionTxt = LeanLocalization.GetTranslationText(unit.Skill);
        string health = unit.GetComponent<Health>().MaxValue.ToString();
        gameObject.SetActive(true);
        _text.text = $"{nameTxt}\n{healthTxt}: {health}\n{skillTxt}: {skillDescriptionTxt}";
        _image.overrideSprite = unit.Sprite;
    }
}