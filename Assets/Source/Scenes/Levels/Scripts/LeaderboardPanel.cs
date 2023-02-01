using Agava.YandexGames;
using UnityEngine;
using TMPro;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _scoreText;

    private string _leaderboardTxt = "Leaderboard";
    private int _topPlayersCount = 7;
    private int _competingPlayers = 1;

    private void OnEnable()
    {       
        GetLeaderboardEntries();
    }

    private void OnDisable()
    {
        _text.text = string.Empty;
        _scoreText.text = string.Empty;
    }

    public void GetLeaderboardEntries()
    {
        Leaderboard.GetEntries(_leaderboardTxt, (result) =>
        {
            foreach (var entry in result.entries)
            {
                string name = entry.player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                _text.text += $"{entry.rank}.{name}\n";
                _scoreText.text += $"{entry.score}\n";
            }
        }, null, _topPlayersCount, _competingPlayers);
    }
}