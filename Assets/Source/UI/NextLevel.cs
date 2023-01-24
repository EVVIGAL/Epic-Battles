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
    private static string _currentLevelStr = "CurrentLevel";

    private void Awake()
    {
        _button = GetComponent<Button>();
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NextScene);

        if (YandexGamesSdk.IsInitialized)
        {
            InterstitialAd.Show(Mute, onCloseCallback: (bool _) => Unpause(), onErrorCallback: (string _) => Unpause(), Unpause);
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void NextScene()
    {
        PlayerPrefs.SetInt(_currentLevelStr, _currentSceneIndex + 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    private void Mute()
    {
        _currentVolume = PlayerPrefs.GetFloat(_volumeTxt);
        _volume.Mute(true);
    }

    private void Unpause()
    {
        if (!Start.IsPause)
            Time.timeScale = 1;

        _volume.SetSlider(_currentVolume);
    }
}