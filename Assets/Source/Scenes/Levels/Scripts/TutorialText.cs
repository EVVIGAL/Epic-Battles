using UnityEngine.UI;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TutorialText : MonoBehaviour
{
    [SerializeField] private TutorialTeamChecker _teamChecker;
    [SerializeField] private Button _startButton;
    [TextArea]
    [SerializeField] private string _text1en;
    [TextArea]
    [SerializeField] private string _text1ru;
    [TextArea]
    [SerializeField] private string _text1tr;
    [TextArea]
    [SerializeField] private string _text2en;
    [TextArea]
    [SerializeField] private string _text2ru;
    [TextArea]
    [SerializeField] private string _text2tr;

    private TextMeshProUGUI _tutorialText;
    private string _ruCode = "ru";
    private string _trCode = "tr";

    private void Awake()
    {
        _tutorialText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {       
        _startButton.onClick.AddListener(Deactivate);
        _teamChecker.IsReady += OnUnitSet;
        SetText1();
        _startButton.interactable = false;
    }

    private void OnDisable()
    {
        _teamChecker.IsReady -= OnUnitSet;
        _startButton.onClick.RemoveListener(Deactivate);
    }

    public void OnUnitSet()
    {
        SetText2();
        _startButton.interactable = true;
    }

    public void OnUnitsDelete()
    {
        SetText1();
        _startButton.interactable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

    private void SetText1()
    {
        if(Yandex.Instance == null)
        {
            _tutorialText.text = _text1en;
            return;
        }

        if (Yandex.Instance.CurrentLanguage == _ruCode)
            _tutorialText.text = _text1ru;
        else if (Yandex.Instance.CurrentLanguage == _trCode)
            _tutorialText.text = _text1tr;
        else
            _tutorialText.text = _text1en;
    }

    private void SetText2()
    {
        if (Yandex.Instance == null)
        {
            _tutorialText.text = _text2en;
            return;
        }

        if (Yandex.Instance.CurrentLanguage == _ruCode)
            _tutorialText.text = _text2ru;
        else if (Yandex.Instance.CurrentLanguage == _trCode)
            _tutorialText.text = _text2tr;
        else
            _tutorialText.text = _text2en;
    }
}