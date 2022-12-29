using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    private int _currentLevel;

    private void Awake()
    {
        LevelHolder.Init();
        _currentLevel = LevelHolder.GetCurrentLevel();
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClick);
    }

    private void OnDisable()
    {
        _playButton.onClick.RemoveAllListeners();
    }

    private void OnPlayClick()
    {
        SceneManager.LoadScene(_currentLevel);
    }
}