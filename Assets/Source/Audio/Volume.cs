using UnityEngine.UI;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _slider;

    private string _volumeTxt = "Volume";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(_volumeTxt))
        {
            _slider.value = PlayerPrefs.GetFloat(_volumeTxt);
            AudioListener.volume = PlayerPrefs.GetFloat(_volumeTxt);
            _toggle.isOn = _slider.value == 0 ? false : true;
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

    public void Mute(bool isntMute)
    {
        if (isntMute)
            _slider.value = 0.5f;
        else
            _slider.value = 0;
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