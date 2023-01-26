using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Circle : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private Coroutine _coroutine;
    private SpriteRenderer _renderer;
    private bool _isActive;
    private float _waitTime = 3f;

    private void OnEnable()
    {
        _renderer = GetComponent<SpriteRenderer>();
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

    public void ActivateCircle()
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
        _renderer.color = new Color(1f, 1f, 1f, 1f);
        yield return new WaitForSeconds(_waitTime);
        _renderer.color = new Color(1f, 1f, 1f, 0.5f);
        gameObject.SetActive(false);
        yield break;
    }
}
