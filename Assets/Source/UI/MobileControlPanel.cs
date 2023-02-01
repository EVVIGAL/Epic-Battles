using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class MobileControlPanel : MonoBehaviour
{
    [SerializeField] private GameObject _mobileContorlPanel;

    private const string _controllerTxt = "MobileController";

    private Toggle _toggle;

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
        _toggle.onValueChanged.RemoveListener(OpenClose);
    }

    private void OpenClose(bool isOn)
    {
        _mobileContorlPanel.SetActive(isOn);
        PlayerPrefs.SetInt(_controllerTxt, isOn ? 1 : 0);
        PlayerPrefs.Save();
    }
}