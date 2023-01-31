using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Circle : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private SpriteRenderer _renderer;
    private Coroutine _coroutine;
    private Color _color;
    private bool _isActive;
    private float _waitTime = 3f;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _color = _renderer.color;
    }

    private void OnDisable()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    private void Update()
    {
        if (_isActive)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                transform.position = hit.point;
        }
    }

    public void Activate()
    {
        _isActive = true;
    }

    public void ActivateAim()
    {
        _isActive = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = StartCoroutine(Use());
        }
        else
        {
            _coroutine = StartCoroutine(Use());
        }
    }

    private IEnumerator Use()
    {
        _renderer.color = Color.red;
        yield return new WaitForSeconds(_waitTime);
        _renderer.color = _color;
        gameObject.SetActive(false);
        yield break;
    }
}