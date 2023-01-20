using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
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
        bool isInteractibleStart = _startButton.IsInteractable();

        if (_settingsPanel.activeSelf)
        {
            _startButton.interactable = isInteractibleStart;
            _settingsPanel.SetActive(false);

            if (_tutorial != null)
                _tutorial.enabled = true;

            if (!Start.IsPause)
                Time.timeScale = 1;
        }
        else
        {
            _startButton.interactable = false;
            _settingsPanel.SetActive(true);

            if (_tutorial != null)
                _tutorial.enabled = false;

            Time.timeScale = 0;
        }
    }
}