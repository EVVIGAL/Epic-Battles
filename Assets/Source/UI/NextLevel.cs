using UnityEngine.SceneManagement;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class NextLevel : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private const string _volumeTxt = "Volume";
    private const string _leaderboardTxt = "Leaderboard";
    private const string _currentLevelStr = "CurrentLevel";

    private Button _button;
    private Scene _currentScene;
    private int _lastLevelIndex;
    private int _loopLevelIndex = 5;
    private int _notPlayableScenesCount = 4;
    private float _currentVolume;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _currentScene = SceneManager.GetSceneAt(0);
        _lastLevelIndex = SceneManager.sceneCountInBuildSettings - _notPlayableScenesCount;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NextScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(NextScene);
    }

    private void NextScene()
    {
        PlayerPrefs.SetInt(_currentLevelStr, _currentScene.buildIndex + 1);
        PlayerPrefs.Save();

        if (YandexGamesSdk.IsInitialized)
        {
            InterstitialAd.Show(Mute, onCloseCallback: (bool _) => LoadNextLEvel(), onErrorCallback: (string _) => LoadNextLEvel(), LoadNextLEvel);
        }
    }

    private void Mute()
    {
        _currentVolume = PlayerPrefs.GetFloat(_volumeTxt);
        AudioListener.volume = 0f;
    }

    private void LoadNextLEvel()
    {
        AudioListener.volume = _currentVolume;
        SetLeaderboardScore();

        if (_currentScene.buildIndex == _lastLevelIndex)
            SceneManager.LoadScene(_loopLevelIndex);
        else
            SceneManager.LoadScene(_currentScene.buildIndex + 1);
    }

    private void SetLeaderboardScore()
    {
        ScoreHolder.Set();

        if (ScoreHolder.CurrentScore >= ScoreHolder.BestScore)
            SaveBestScore(ScoreHolder.CurrentScore);
    }

    private void SaveBestScore(int bestScore)
    {
        Leaderboard.SetScore(_leaderboardTxt, bestScore);
    }
}