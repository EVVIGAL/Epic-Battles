using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();      
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NextScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(NextScene);
    }

    private void NextScene()
    {      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}