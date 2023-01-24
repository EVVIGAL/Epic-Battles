using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMerger : MonoBehaviour
{
    [SerializeField] private string _environmentSceneName;

    private void Awake()
    {
        SceneManager.LoadScene(_environmentSceneName, LoadSceneMode.Additive);
    }
}