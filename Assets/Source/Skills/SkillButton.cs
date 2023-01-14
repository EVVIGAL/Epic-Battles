using UnityEngine.UI;
using UnityEngine;

public class SkillButton : MonoBehaviour
{
    [SerializeField] private GameObject _skillTxt;
    [SerializeField] private SkillCaster _caster;
    [SerializeField] private Unit _neededUnit;
    [SerializeField] private UnitsObserver _observer;
    [SerializeField] private int _skillIndex;
    [SerializeField] private int _amount;

    private Button _button;
    private Image _image;

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
        _button.onClick.RemoveAllListeners();
    }

    private void ActivateSkill()
    {
        if (_amount <= 0)
            return;

        if (_observer.CheckForUnit(_neededUnit))
        {
            _amount--;
            _caster.Activate(_skillIndex);
            _skillTxt.SetActive(true);

            if(_amount <= 0)
                _image.color = Color.gray;
        }
    }
}