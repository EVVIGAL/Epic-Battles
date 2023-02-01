using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMover : MonoBehaviour
{
    [Header("Bounds")]
    [SerializeField] private float _leftBound;
    [SerializeField] private float _rightBound;
    [SerializeField] private float _upBound;
    [SerializeField] private float _downBound;
    [Header("Move parameters")]
    [SerializeField] private float _speed;
    [Header("Zoom")]
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _zoomDistance;
    [Header("Position")]
    [SerializeField] private Quaternion _startRotation;
    [SerializeField] private Vector3 _startPosition;

    private Camera _camera;
    private Zoom _zoomBounds;

    private const string _mouseWheel = "Mouse ScrollWheel";

    private float _minZoom = 15f;
    private float _maxZoom = 70f;
    private float _wheelSpeedMultiplier = 3f;

    public float MinZoom => _minZoom;

    public float MaxZoom => _maxZoom;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _camera.fieldOfView = _maxZoom;
        _camera.transform.position = _startPosition;
        _camera.transform.rotation = _startRotation;
        _zoomBounds = new(_leftBound, _rightBound, _upBound, _downBound);
    }

    private void Update()
    {
        Move(GetDirection());

        if (Input.GetKey(KeyCode.E))
            ZoomIn();

        if (Input.GetKey(KeyCode.Q))
            ZoomOut();

        if (Input.GetAxis(_mouseWheel) > 0)
            ZoomIn(_wheelSpeedMultiplier);

        if (Input.GetAxis(_mouseWheel) < 0)
            ZoomOut(_wheelSpeedMultiplier);
    }

    public void Move(Vector3 direction)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(Mathf.Clamp(transform.position.x, _zoomBounds.Left, _zoomBounds.Right), transform.position.y, Mathf.Clamp(transform.position.z, _zoomBounds.Bottom, _zoomBounds.Top)) + direction, Time.unscaledDeltaTime * _speed);
    }

    private Vector3 GetDirection()
    {
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            direction.x = -1;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            direction.x = 1;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            direction.z = 1;

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            direction.z = -1;

        return direction;
    }

    public void ZoomIn(float multiplier = 1f)
    {      
        _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, _minZoom, Time.unscaledDeltaTime * _zoomSpeed * multiplier);
    }

    public void ZoomOut(float multiplier = 1f)
    {
        _camera.fieldOfView = Mathf.MoveTowards(_camera.fieldOfView, _maxZoom, Time.unscaledDeltaTime * _zoomSpeed * multiplier);
    }
}