using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class TutorialText : MonoBehaviour
{
    [SerializeField] private TutorialTeamChecker _teamChecker;
    [SerializeField] private Button _startButton;
    [SerializeField] private string _text1;
    [SerializeField] private string _text2;

    private TextMeshProUGUI _tutorialText;

    private void Awake()
    {
        _tutorialText = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(Deactivate);
        _teamChecker._isReady += OnUnitSet;
        _teamChecker._notReady += OnUnitsDelete;
        _tutorialText.text = _text1;
        _startButton.interactable = false;
    }

    private void OnDisable()
    {
        _teamChecker._isReady -= OnUnitSet;
        _teamChecker._notReady -= OnUnitsDelete;
        _startButton.onClick.RemoveListener(Deactivate);
    }

    public void OnUnitSet()
    {
        _tutorialText.text = _text2;
        _startButton.interactable = true;
    }

    public void OnUnitsDelete()
    {
        _tutorialText.text = _text1;
        _startButton.interactable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}