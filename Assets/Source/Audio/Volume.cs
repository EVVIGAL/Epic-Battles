using UnityEngine.UI;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _slider;

    private string _volumeTxt = "Volume";
    private float _defaultVolume = 0.5f;

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_volumeTxt))
        {
            _slider.value = PlayerPrefs.GetFloat(_volumeTxt);
            AudioListener.volume = PlayerPrefs.GetFloat(_volumeTxt);
            _toggle.isOn = _slider.value != 0;
        }
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(SetVolume);
        _toggle.onValueChanged.AddListener(Mute);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(SetVolume);
        _toggle.onValueChanged.RemoveListener(Mute);
    }

    public void Mute(bool isntMute)
    {
        if (isntMute)
        {
            if(PlayerPrefs.HasKey(_volumeTxt))
                _slider.value = PlayerPrefs.GetFloat(_volumeTxt);
            else
                _slider.value = _defaultVolume;
        }
        else
        {
            _slider.value = 0;
        }
    }

    public void SetSlider(float volume)
    {
        _slider.value = volume;
    }

    private void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat(_volumeTxt, volume);
        PlayerPrefs.Save();

        if(_slider.value == 0)
            _toggle.isOn = false;

        if (_slider.value > 0)
            _toggle.isOn = true;
    }
}