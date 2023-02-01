using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class MenuButton : MonoBehaviour
{
    private Button _button;
    private int _menuIndex = 1;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(BackToMenu);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(BackToMenu);
    }

    private void BackToMenu()
    {
        SceneManager.LoadScene(_menuIndex);
    }
}