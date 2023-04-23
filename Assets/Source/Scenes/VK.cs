using DungeonGames.VKGames;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VK : MonoBehaviour
{
    public static VK Instance;
    private int _startSceneIndex = 1;

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
    }

    private void Start()
    {
        InitializeSdkButton();
    }

    private void InitializeSdkButton()
    {
        StartCoroutine(InitializeSDK());
    }

    private IEnumerator InitializeSDK()
    {
        yield return VKGamesSdk.Initialize(onSuccessCallback: OnSDKInitilized);
    }

    private void OnSDKInitilized()
    {
        SceneManager.LoadScene(_startSceneIndex);
    }
}