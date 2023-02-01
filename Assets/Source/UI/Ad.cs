using Agava.YandexGames;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class Ad : MonoBehaviour
{
    [SerializeField] private Volume _volume;
    [SerializeField] private Money _money;

    private const string _volumeTxt = "Volume";

    private Button _button;
    private float _currentVolume;
    private int _reward = 50;
    private int _possibleRewardCount = 2;

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
        if (YandexGamesSdk.IsInitialized)
        {
            Time.timeScale = 0;
            VideoAd.Show(Mute, GiveReward, Unpause, null);
        }
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