using UnityEngine;
using UnityEngine.UI;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
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
            _startButton.enabled = true;
            _settingsPanel.SetActive(false);

            if (!Start.IsPause)
                Time.timeScale = 1;
        }
        else
        {
            _startButton.enabled = false;
            _settingsPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}