using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private int _fontSize = 20;
    [SerializeField] private Vector2 _position;
    [SerializeField] private Color _color = Color.black;
    [SerializeField] private float _updateInterval = 0.5f;

    private float _accum = 0.0f;
    private int _frames = 0;
    private float _timeleft;
    private float _fps;
    private GUIStyle _textStyle = new GUIStyle();

    private void Start()
    {
        _timeleft = _updateInterval;
        _textStyle.fontStyle = FontStyle.Bold;
    }

    private void Update()
    {
        _timeleft -= Time.deltaTime;
        _accum += Time.timeScale / Time.deltaTime;
        ++_frames;

        if (_timeleft <= 0.0)
        {
            _fps = (_accum / _frames);
            _timeleft = _updateInterval;
            _accum = 0.0f;
            _frames = 0;
        }
    }

    private void OnGUI()
    {
        _textStyle.fontSize = _fontSize;
        _textStyle.normal.textColor = _color;
        GUI.Label(new Rect(_position.x + Screen.width, _position.y, 100, 25), _fps.ToString("F2") + "FPS", _textStyle);
    }
}