using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class ZoomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] protected Camera _camera;

    protected CameraMover _cameraMover;
    private Coroutine _zoom;

    private void Awake()
    {
        _cameraMover = _camera.GetComponent<CameraMover>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(_zoom != null)
        {
            StopCoroutine(_zoom);
            _zoom = StartCoroutine(Zoom());
        }
        else
        {
            _zoom = StartCoroutine(Zoom());
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_zoom != null)
            StopCoroutine(_zoom);
    }

    public virtual IEnumerator Zoom()
    {
        while (true)
        {
            _cameraMover.ZoomIn();
            yield return null;
        }
    }
}