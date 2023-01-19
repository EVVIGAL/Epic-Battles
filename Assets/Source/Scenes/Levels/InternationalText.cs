using UnityEngine;
using TMPro;

public class InternationalText : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;
    [SerializeField] private string _tr;

    private TextMeshProUGUI _text;
    private string EnglishCode = "en";
    private string RussianCode = "ru";
    private string TurkishCode = "tr";

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        if (Yandex.Instance == null)
        {
            _text.text = _en;
            return;
        }

        if (Yandex.Instance.CurrentLanguage == EnglishCode)
            _text.text = _en;
        else if (Yandex.Instance.CurrentLanguage == RussianCode)
            _text.text = _ru;
        else if (Yandex.Instance.CurrentLanguage == TurkishCode)
            _text.text = _tr;
        else
            _text.text = _en;
    }
}