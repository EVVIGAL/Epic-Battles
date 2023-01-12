using UnityEngine.UI;
using UnityEngine;

public class Volume : MonoBehaviour
{
    [SerializeField] private Toggle _toggle;
    [SerializeField] private Slider _slider;

    private string _volumeTxt = "Volume";
    private string _muteTxt = "Mute";

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_volumeTxt);    
        _toggle.isOn = PlayerPrefs.GetInt(_muteTxt) == 1 ? true : false;
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
    }

    private void Mute(bool isMute)
    {
        AudioListener.pause = !isMute;
        PlayerPrefs.SetInt(_muteTxt, isMute ? 1 : 0);
    }
}