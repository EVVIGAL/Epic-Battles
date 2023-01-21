using UnityEngine;
using UnityEngine.UI;

public class MobileControlPanel : MonoBehaviour
{
    [SerializeField] private GameObject _mobileContorlPanel;

    private Toggle _toggle;
    private string _controllerTxt = "MobileController";

    private void Awake()
    {
        _toggle = GetComponent<Toggle>();

        if (PlayerPrefs.HasKey(_controllerTxt))
            _toggle.isOn = PlayerPrefs.GetInt(_controllerTxt) == 1 ? true : false;
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
        _mobileContorlPanel.SetActive(isOn);
        PlayerPrefs.SetInt(_controllerTxt, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}