using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider _healthSlider;

    private void Awake()
    {
        _healthSlider = GetComponent<Slider>();
    }

    public void Show(uint currentValue, uint maxValue)
    {
        _healthSlider.value = (float)currentValue / maxValue;
    }
}