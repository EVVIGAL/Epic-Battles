using UnityEngine.SceneManagement;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class Restart : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private const string _volumeTxt = "Volume";

    private Button _button;
    private Scene _currentScene;
    private float _currentVolume;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _currentScene = SceneManager.GetSceneAt(0);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(RestartWithAd);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(RestartWithAd);
    }

    private void RestartWithAd()
    {
        if (YandexGamesSdk.IsInitialized)
            InterstitialAd.Show(Mute, onCloseCallback: (bool _) => RestartLevel(), onErrorCallback: (string _) => RestartLevel(), RestartLevel);
    }

    private void Mute()
    {
        _currentVolume = PlayerPrefs.GetFloat(_volumeTxt);
        AudioListener.volume = 0f;
    }

    public void RestartLevel()
    {
        AudioListener.volume = _currentVolume;
        SceneManager.LoadScene(_currentScene.name);
    }
}