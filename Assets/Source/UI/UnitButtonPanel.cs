using UnityEngine.UI;
using UnityEngine;

public class UnitButtonPanel : MonoBehaviour
{
    private Button[] _buttons;

    private void Awake()
    {
        _buttons = GetComponentsInChildren<Button>();
    }

    public void Activate(bool isInteractable)
    {
        for(int i = 0; i < _buttons.Length; i++)
        {
            _buttons[i].interactable = isInteractable;
        }
    }
}
