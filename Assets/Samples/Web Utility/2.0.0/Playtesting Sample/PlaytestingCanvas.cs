using UnityEngine;
using UnityEngine.UI;

namespace Agava.WebUtility.Samples
{
    public class PlaytestingCanvas : MonoBehaviour
    {
        [SerializeField] private Slider _slider;

        private const string _volumeTxt = "Volume";

        private void OnEnable()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
        }

        private void OnDisable()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            if (_slider != null)
            {
                if (_slider.value == 0)
                    return;
            }

            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : PlayerPrefs.GetFloat(_volumeTxt);
        }
    }
}