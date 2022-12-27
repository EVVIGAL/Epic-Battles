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
    private Zoom _zoomBounds;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
        _zoomInButton.onClick.AddListener(ZoomIn);
        _zoomOutButton.onClick.AddListener(ZoomOut);
        _zoomBounds = new(_leftBound, _rightBound, _upBound, _downBound);
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
        if (_zoomBounds.ZoomCount < _zoomBounds.MaxZoom)
        {
            _zoomBounds.ZoomIn();

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
        if (_zoomBounds.ZoomCount > _zoomBounds.MinZoom)
        {
            _zoomBounds.ZoomOut();

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
        _transform.position = Vector3.Lerp(_transform.position, new Vector3(Mathf.Clamp(_transform.position.x, _zoomBounds.Left, _zoomBounds.Right), _transform.position.y, Mathf.Clamp(_transform.position.z, _zoomBounds.Bottom, _zoomBounds.Top)) + direction, Time.deltaTime * _speed);
    }

    private IEnumerator Zoom(float zoomDistance)
    {
        bool zoomed = false;
        float offset = 0.09f;
        float slowSpeed = 1;
        float normalSpeed = _speed;
        float targetY = _transform.position.y + zoomDistance;

        while (zoomed == false)
        {
            if(_transform.position.x <= _zoomBounds.Left || _transform.position.x >= _zoomBounds.Right || _transform.position.z >= _zoomBounds.Top)
                _speed = slowSpeed;

            Vector3 zoomTarget = new(Mathf.Clamp(_transform.position.x, _zoomBounds.Left, _zoomBounds.Right), targetY, Mathf.Clamp(_transform.position.z, _zoomBounds.Bottom, _zoomBounds.Top));
            _transform.position = Vector3.Lerp(_transform.position, zoomTarget, Time.deltaTime * _zoomSpeed);
            yield return null;

            if(_transform.position.y >= targetY - offset && _transform.position.y <= targetY + offset)
                zoomed = true;
        }

        _speed = normalSpeed;
    }
}