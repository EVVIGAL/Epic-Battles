using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelCounter : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private int _levelIndex;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _levelIndex = SceneManager.GetActiveScene().buildIndex;
        _levelIndex--;
    }

    private void OnEnable()
    {
        _text.text = _levelIndex.ToString();
    }
}