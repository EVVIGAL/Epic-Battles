using UnityEngine;

public static class LevelHolder
{
    private static string _currentLevelStr = "CurrentLevel";
    private static int _defaultCurrentLevel = 2;
    private static int _currentLevel;

    public static void Init()
    {
        _currentLevel = PlayerPrefs.GetInt(_currentLevelStr, _defaultCurrentLevel);
    }

    public static int GetCurrentLevel()
    {
        return _currentLevel;
    }

    public static void SetCurrentLevel(int level)
    {
        PlayerPrefs.SetInt(_currentLevelStr, level);
    }
}