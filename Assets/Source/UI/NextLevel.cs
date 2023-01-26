using UnityEngine.SceneManagement;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private Button _button;
    private int _currentSceneIndex;
    private float _currentVolume;
    private string _volumeTxt = "Volume";
    private string _leaderboardTxt = "Leaderboard";
    private const string _currentLevelStr = "CurrentLevel";
    private const string _bestLevelStr = "BestLevel";

    private void Awake()
    {
        _button = GetComponent<Button>();
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
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
        PlayerPrefs.SetInt(_currentLevelStr, _currentSceneIndex + 1);
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
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    private void SetLeaderboardScore()
    {
        if (PlayerPrefs.HasKey(_bestLevelStr))
        {
            int bestScore = PlayerPrefs.GetInt(_bestLevelStr);

            if(bestScore < _currentSceneIndex + 1)
                SaveBestScore(_currentSceneIndex);
        }
        else
        {
            int bestScore = _currentSceneIndex;
            SaveBestScore(bestScore);
        }
    }

    private void SaveBestScore(int bestScore)
    {
        PlayerPrefs.SetInt(_bestLevelStr, bestScore);
        PlayerPrefs.Save();
        Leaderboard.SetScore(_leaderboardTxt, bestScore);
    }
}