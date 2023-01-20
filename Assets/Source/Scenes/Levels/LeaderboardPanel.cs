using Agava.YandexGames;
using UnityEngine;
using TMPro;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private string _leaderboardTxt = "Leaderboard";
    private int _topCount = 7;

    private void OnEnable()
    {       
        GetLeaderboardEntries();
    }

    private void OnDisable()
    {
        _text.text = string.Empty;
    }

    public void GetLeaderboardEntries()
    {
        Leaderboard.GetEntries(_leaderboardTxt, (result) =>
        {
            for (int i = 0; i < _topCount; i++)
            {
                string name = result.entries[i].player.publicName;

                if (string.IsNullOrEmpty(name))
                    name = "Anonymous";

                _text.text += $"{i + 1} - {name} - {result.entries[i].score}\n";
            }
        });
    }
}