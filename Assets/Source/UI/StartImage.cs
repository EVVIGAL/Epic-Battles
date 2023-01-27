using UnityEngine.UI;
using UnityEngine;

public class StartImage : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    private Color _tempColor;
    private Color _color;
    private Image _image;
    private float _temporaryAlpha = 0.5f;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _color = _image.color;
        _tempColor = _image.color;
        _tempColor.a = _temporaryAlpha;
    }

    private void Update()
    {
        if (_startButton.interactable)
            _image.color = _color;
        else
            _image.color = _tempColor;

        if(Time.timeScale > 0)
            enabled = false;
    }
}