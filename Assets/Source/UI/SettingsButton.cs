using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private EndBattle _endPanel;
    [SerializeField] private TextMeshProUGUI _tutorial;
    [SerializeField] private Button _startButton;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OpenClose);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OpenClose()
    {
        if (_settingsPanel.activeSelf)
        {
            if (!_startButton.IsInteractable())
                _startButton.interactable = true;

            _settingsPanel.SetActive(false);
            _endPanel.gameObject.SetActive(_endPanel.IsFinished);

            if (_tutorial != null)
                _tutorial.enabled = true;

            if (!Start.IsPause)
                Time.timeScale = 1;
        }
        else
        {
            if (_startButton.IsInteractable())
                _startButton.interactable = false;

            _settingsPanel.SetActive(true);
            _endPanel.gameObject.SetActive(false);

            if (_tutorial != null)
                _tutorial.enabled = false;

            Time.timeScale = 0;
        }
    }
}