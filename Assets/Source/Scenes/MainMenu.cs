using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _leaderboardPanel;

    private static string _currentLevelStr = "CurrentLevel";
    private static int _firstLevelIndex = 2;
    private static int _currentLevelIndex;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_currentLevelStr))
        {
            _continueButton.gameObject.SetActive(true);
            _currentLevelIndex = PlayerPrefs.GetInt(_currentLevelStr);
        }
        else
        {
            _continueButton.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClick);
        _continueButton.onClick.AddListener(OnContinueClick);
        _settingsButton.onClick.AddListener(OnSettingsClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveListener(OnPlayClick);
        _continueButton.onClick.RemoveListener(OnContinueClick);
        _settingsButton.onClick.RemoveListener(OnSettingsClick);
    }

    private void OnContinueClick()
    {
        SceneManager.LoadScene(_currentLevelIndex);
    }

    private void OnPlayClick()
    {
        PlayerPrefs.SetInt(_currentLevelStr, _firstLevelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(_firstLevelIndex);
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