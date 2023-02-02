using UnityEngine;

public static class ScoreHolder
{
    private static string _bestScoreStr = "BestScore";
    private static string _currentScoreStr = "BestScore";
    private static int _bestScore;
    private static int _currentScore;

    public static int BestScore => _bestScore;

    public static int CurrentScore => _currentScore;

    public static void Init()
    {
        if(PlayerPrefs.HasKey(_bestScoreStr))
            _bestScore = PlayerPrefs.GetInt(_bestScoreStr);
        else
            _bestScore = 0;

        if (PlayerPrefs.HasKey(_currentScoreStr))
            _currentScore = PlayerPrefs.GetInt(_currentScoreStr);
        else
            _currentScore = 0;
    }

    public static void Refresh()
    {
        _currentScore = 0;
        SetCurrent();
    }

    public static void Set()
    {
        _currentScore++;

        if (_currentScore >= _bestScore)
            SetBest(_currentScore);

        SetCurrent();
    }

    private static void SetBest(int bestScore)
    {
        _bestScore = bestScore;
        PlayerPrefs.SetInt(_bestScoreStr, _bestScore);
        PlayerPrefs.Save();
    }

    private static void SetCurrent()
    {
        PlayerPrefs.SetInt(_currentScoreStr, _currentScore);
        PlayerPrefs.Save();
    }
}