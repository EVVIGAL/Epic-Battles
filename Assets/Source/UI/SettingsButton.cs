using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SettingsButton : MonoBehaviour
{
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private TextMeshProUGUI _tutorial;
    [SerializeField] private Button _startButton;
    [SerializeField] private UnitButtonPanel _unitPanel;

    private Button _button;
    private bool _isInteractableStart;

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
        _button.onClick.RemoveListener(OpenClose);
    }

    private void OpenClose()
    {
        if (_settingsPanel.activeSelf)
        {
            _startButton.interactable = _isInteractableStart;

            _settingsPanel.SetActive(false);

            if (_tutorial != null)
                _tutorial.enabled = true;

            if (!Start.IsPause)
                Time.timeScale = 1;

            _unitPanel.Activate(true);
        }
        else
        {
            _isInteractableStart = _startButton.interactable;

            if (_startButton.IsInteractable())
                _startButton.interactable = false;

            _settingsPanel.SetActive(true);

            if (_tutorial != null)
                _tutorial.enabled = false;

            _unitPanel.Activate(false);

            Time.timeScale = 0;
        }
    }
}