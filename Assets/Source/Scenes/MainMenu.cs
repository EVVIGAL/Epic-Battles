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
    [SerializeField] private GameObject _authorizationPanel;
    [SerializeField] private GameObject _mainPanel;

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
        ScoreHolder.Init();
        SceneManager.LoadScene(_currentLevelIndex);
    }

    private void OnPlayClick()
    {
        ScoreHolder.Init();
        ScoreHolder.Refresh();
        PlayerPrefs.SetInt(_currentLevelStr, _firstLevelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(_firstLevelIndex);
    }

    private void OnSettingsClick()
    {
        _leaderboardPanel.SetActive(false);
        _authorizationPanel.SetActive(false);
        _settingsPanel.SetActive(!_settingsPanel.activeSelf);
        _mainPanel.SetActive(false);
    }
}