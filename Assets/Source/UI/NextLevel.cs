using UnityEngine.SceneManagement;
using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private Button _button;
    private int _currentSceneIndex;
    private string _muteTxt = "Mute";

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
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    private void Mute()
    {
        AudioListener.pause = true;
    }

    private void Unpause()
    {
        if (!Start.IsPause)
            Time.timeScale = 1;

        AudioListener.pause = PlayerPrefs.GetInt(_muteTxt) == 1 ? true : false;
    }
}