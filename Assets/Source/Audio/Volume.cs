using UnityEngine.UI;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _slider;

    private string _volumeTxt = "Volume";
    private string _muteTxt = "Mute";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_volumeTxt))
        {
            _slider.value = PlayerPrefs.GetFloat(_volumeTxt);
            AudioListener.volume = PlayerPrefs.GetFloat(_volumeTxt);
        }

        if (PlayerPrefs.HasKey(_muteTxt))
        {
            _toggle.isOn = PlayerPrefs.GetInt(_muteTxt) == 1 ? true : false;
            AudioListener.pause = PlayerPrefs.GetInt(_muteTxt) == 1 ? false : true;
        }
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
        _toggle.onValueChanged.AddListener(Mute);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveAllListeners();
        _toggle.onValueChanged.RemoveAllListeners();
    }

    private void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(_volumeTxt, volume);
        PlayerPrefs.Save();
    }

    private void Mute(bool isMute)
    {
        AudioListener.pause = !isMute;
        PlayerPrefs.SetInt(_muteTxt, isMute ? 1 : 0);
        PlayerPrefs.Save();
    }
}