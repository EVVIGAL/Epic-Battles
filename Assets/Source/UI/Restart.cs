using UnityEngine.SceneManagement;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] private Volume _volume;

    private Button _button;
    private float _currentVolume;
    private string _volumeTxt = "Volume";

    private void Awake()
    {
        _button = GetComponent<Button>();
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
        {
            InterstitialAd.Show(Mute, onCloseCallback: (bool _) => RestartLevel(), onErrorCallback: (string _) => RestartLevel(), RestartLevel);
        }
    }

    private void Mute()
    {
        _currentVolume = PlayerPrefs.GetFloat(_volumeTxt);
        AudioListener.volume = 0f;
    }

    public void RestartLevel()
    {
        AudioListener.volume = _currentVolume;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}