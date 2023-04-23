using UnityEngine.UI;
using UnityEngine;
using DungeonGames.VKGames;
#if YANDEX_GAMES
using Agava.YandexGames;
#endif

[RequireComponent(typeof(Button))]
public class Ad : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private Money _money;

    private const string _volumeTxt = "Volume";

    private Button _button;
    private float _currentVolume;
    private int _reward = 50;
    private int _possibleRewardCount = 5;

    private void Awake()
    {
        _button = GetComponentInParent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
#if VK_GAMES
        VideoAd.Show(GiveReward);
#endif
#if YANDEX_GAMES
        if (YandexGamesSdk.IsInitialized)
        {
            Time.timeScale = 0;
            VideoAd.Show(Mute, GiveReward, Unpause, null);
        }
#endif
    }

    private void GiveReward()
    {
        _money.AddMoney(_reward);
        _possibleRewardCount--;

        if(_possibleRewardCount <= 0)
            gameObject.SetActive(false);
    }

    private void Mute()
    {
        _currentVolume = PlayerPrefs.GetFloat(_volumeTxt);
        _volume.Mute(false);
    }

    private void Unpause()
    {
        if (!Start.IsPause)
            Time.timeScale = 1;

        _volume.SetSlider(_currentVolume);
    }
}