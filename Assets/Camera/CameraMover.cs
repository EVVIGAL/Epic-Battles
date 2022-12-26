using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private float _zoomIn;
    [SerializeField] private float _zoomOut;
    [Header("Buttons")]
    [SerializeField] private Button _zoomInButton;
    [SerializeField] private Button _zoomOutButton;

    private Transform _transform;
    private Coroutine _zoom;
    private float _maxY;
    private float _minY;
    private float _zoomCounter;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _zoomInButton.onClick.AddListener(ZoomIn);
        _zoomOutButton.onClick.AddListener(ZoomOut);
        _zoomCounter = 1.9f;
    }

    private void Start()
    {
        _maxY = _transform.position.y + _zoomOut * _zoomCounter;
        _minY = _transform.position.y - _zoomIn * _zoomCounter;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector3.right);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Move(Vector3.forward);
        }

        if (Input.GetKey(KeyCode.S))
        {
            Move(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            ZoomIn();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ZoomOut();
        }
    }

    private void ZoomIn()
    {
        if (_transform.position.y > _minY)
        {
            if (_zoom != null)
            {
                StopCoroutine(_zoom);
                _zoom = StartCoroutine(Zoom(-_zoomIn));
            }
            else
            {
                _zoom = StartCoroutine(Zoom(-_zoomIn));
            }
        }
    }

    private void ZoomOut()
    {
        if (_transform.position.y < _maxY)
        {
            if (_zoom != null)
            {
                StopCoroutine(_zoom);
                _zoom = StartCoroutine(Zoom(_zoomIn));
            }
            else
            {
                _zoom = StartCoroutine(Zoom(_zoomIn));
            }
        }
    }

    private void Move(Vector3 direction)
    {
        _transform.position = Vector3.Lerp(_transform.position, _transform.position + direction, Time.deltaTime * _speed);
        _transform.position = new Vector3(Mathf.Clamp(_transform.position.x, _leftBound, _rightBound),
                                          _transform.position.y,
                                          Mathf.Clamp(_transform.position.z, _downBound, _upBound));
    }

    private IEnumerator Zoom(float zoomDistance)
    {
        float targetY = _transform.position.y + zoomDistance;

        while (_transform.position.y != targetY)
        {
            Vector3 zoomTarget = new(_transform.position.x, targetY, _transform.position.z);
            _transform.position = Vector3.Lerp(_transform.position, zoomTarget, Time.deltaTime * _zoomSpeed);
            yield return null;
        }
    }
}