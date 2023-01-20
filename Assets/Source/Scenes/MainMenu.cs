using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _leaderboardPanel;

    private int _currentLevel;

    private void Awake()
    {
        LevelHolder.Init();
        _currentLevel = LevelHolder.GetCurrentLevel();
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClick);
        _settingsButton.onClick.AddListener(OnSettingsClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveAllListeners();
        _settingsButton.onClick.RemoveAllListeners();
    }

    private void OnPlayClick()
    {
        SceneManager.LoadScene(_currentLevel);
    }

    private void OnSettingsClick()
    {
        if (_leaderboardPanel.activeSelf)
            _leaderboardPanel.SetActive(false);

        if (_settingsPanel.activeSelf)
            _settingsPanel.SetActive(false);
        else
            _settingsPanel.SetActive(true);

    }
}