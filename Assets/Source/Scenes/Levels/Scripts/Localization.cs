using System.Collections.Generic;
using Lean.Localization;
using UnityEngine;

public class Localization : MonoBehaviour
{
    private LeanLocalization _localization;
    private const string _defaultKey = "en";

    private Dictionary<string, string> _languageISO639_1Codes = new()
    {
        { "ru", "Russian" },
        { "en", "English" },
        { "tr", "Turkish" },
    };

    private void Awake()
    {
        _localization = GetComponent<LeanLocalization>();
    }

    private void Start()
    {
        Set();
    }

    public void Set()
    {
        if (Yandex.Instance == null)
        {
            _localization.SetCurrentLanguage(_languageISO639_1Codes[_defaultKey]);
            return;
        }

        _localization.SetCurrentLanguage(_languageISO639_1Codes[Yandex.Instance.CurrentLanguage]);
    }
}