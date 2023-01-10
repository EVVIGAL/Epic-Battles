using UnityEngine;
using UnityEngine.UI;

public class MobileControlPanel : MonoBehaviour
{
    [SerializeField] private GameObject _mobileContorlPanel;

    private Toggle _toggle;

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }

    private void OnEnable()
    {
        _toggle.onValueChanged.AddListener(OpenClose);
    }

    private void OnDisable()
    {
        _toggle.onValueChanged.RemoveAllListeners();
    }

    private void OpenClose(bool isOn)
    {
        if(isOn)
            _mobileContorlPanel.SetActive(true);
        else
            _mobileContorlPanel.SetActive(false);
    }
}