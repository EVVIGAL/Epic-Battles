using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _skillTxt;
    [SerializeField] private SkillCaster _caster;
    [SerializeField] private UnitsObserver _observer;
    [SerializeField] private int _skillIndex;

    private Button _button;
    private Image _image;

    public event UnityAction OnActivateSkill;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(ActivateSkill);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ActivateSkill);
    }

    public void ActivateSkill()
    {
        _caster.Activate(_skillIndex);
        _skillTxt.gameObject.SetActive(true);
        OnActivateSkill?.Invoke();
    }

    public void Deactivate(int skillCount)
    {
        _button.interactable = false;
        _image.color = Color.gray;

        if(skillCount > 0)
            gameObject.SetActive(false);
    }

    public void Activate()
    {
        _button.interactable = true;
        _image.color = Color.white;
        gameObject.SetActive(true);
    }
}