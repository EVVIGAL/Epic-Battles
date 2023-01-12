using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private Button _button;
    private int _currentSceneIndex;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(NextScene);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    public void NextScene()
    {
        SceneManager.LoadScene(++_currentSceneIndex);
    }
}