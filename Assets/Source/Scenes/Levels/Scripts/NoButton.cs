using UnityEngine.UI;
using UnityEngine;

public class NoButton : MonoBehaviour
{
    [SerializeField] private GameObject _authorizationPanel;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Close);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(Close);
    }

    private void Close()
    {
        _authorizationPanel.SetActive(false);
    }
}