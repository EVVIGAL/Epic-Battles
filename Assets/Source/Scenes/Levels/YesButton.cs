using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

public class YesButton : MonoBehaviour
{
    [SerializeField] private GameObject _authorizationPanel;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Authorize);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Authorize()
    {
        if (YandexGamesSdk.IsInitialized)
        {
            _authorizationPanel.SetActive(false);
            PlayerAccount.Authorize();
        }
    }
}