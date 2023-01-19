#pragma warning disable
using UnityEngine.SceneManagement;
using System.Collections;
using Agava.YandexGames;
using UnityEngine;

public class Yandex : MonoBehaviour
{
    public static Yandex Instance;
    private string _language;
    private int _startSceneIndex = 1;

    public string CurrentLanguage => _language;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        YandexGamesSdk.CallbackLogging = true;
    }

    private IEnumerator Start()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        yield break;
#endif

        yield return YandexGamesSdk.Initialize();
        _language = YandexGamesSdk.Environment.i18n.lang;

        if (YandexGamesSdk.IsInitialized)
            SceneManager.LoadScene(_startSceneIndex);
    }
}