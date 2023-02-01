using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class LeaderboardButton : MonoBehaviour
{
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private GameObject _authorizationPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _mainPanel;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OpenLeaderboard);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OpenLeaderboard);
    }

    private void OpenLeaderboard()
    {
        if (!YandexGamesSdk.IsInitialized)
            return;

        _settingsPanel.SetActive(false);

        if (PlayerAccount.IsAuthorized)
        {
            _leaderboardPanel.SetActive(!_leaderboardPanel.activeSelf);
            _mainPanel.SetActive(false);
        }
        else
        {
            _authorizationPanel.SetActive(true);
            _mainPanel.SetActive(false);
        }
    }
}