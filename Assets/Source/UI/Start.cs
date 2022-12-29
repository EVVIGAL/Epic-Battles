using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _line;

    private Button _startButton;

    private void Awake()
    {
        _startButton = GetComponent<Button>();
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(StartBattle);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(StartBattle);
    }

    public void StartBattle()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        _slider.SetActive(true);
        _line.SetActive(false);
    }
}