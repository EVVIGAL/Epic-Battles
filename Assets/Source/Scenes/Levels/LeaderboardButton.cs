using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

public class LeaderboardButton : MonoBehaviour
{
    [SerializeField] private GameObject _leaderboardPanel;
    [SerializeField] private GameObject _authorizationPanel;

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
        _button.onClick.RemoveAllListeners();
    }

    private void OpenLeaderboard()
    {
        if(!YandexGamesSdk.IsInitialized)
            return;

        if (PlayerAccount.IsAuthorized)
        {
            if(_leaderboardPanel.activeSelf)
                _leaderboardPanel.SetActive(false);
            else
                _leaderboardPanel.SetActive(true);
        }
        else
        {
            _authorizationPanel.SetActive(true);
        }
    }
}