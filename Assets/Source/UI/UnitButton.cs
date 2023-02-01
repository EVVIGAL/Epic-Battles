using UnityEngine.EventSystems;
using UnityEngine;

public class UnitButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _info;

    private bool _isSelected;

    public void OnPointerDown(PointerEventData eventData)
    {
        _isSelected = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        _info.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(!_isSelected)
            _info.SetActive(false);
    }
}