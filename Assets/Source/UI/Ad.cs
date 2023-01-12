using UnityEngine;
using Agava.YandexGames;
using UnityEngine.UI;

public class Ad : MonoBehaviour
{
    private Button _button;
    private Money _money;
    private int _reward = 50;
    private string _muteTxt = "Mute";

    private void Awake()
    {
        _money = GetComponentInParent<Money>();
        _button = GetComponentInParent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void OnButtonClick()
    {
        if (YandexGamesSdk.IsInitialized)
        {
            Time.timeScale = 0;
            VideoAd.Show(Mute, GiveReward, Unpause, null);
        }
    }

    private void GiveReward()
    {
        _money.AddMoney(_reward);
    }

    private void Mute()
    {
        AudioListener.pause = true;
    }

    private void Unpause()
    {
        if (!Start.IsPause)
            Time.timeScale = 1;

        AudioListener.pause = PlayerPrefs.GetInt(_muteTxt) == 1 ? true : false;
    }
}