using UnityEngine;
using UnityEngine.UI;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _line;
    [SerializeField] private GameObject _adButton;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private UnitsObserver _observer;

    private static bool _isPause;

    private Button _startButton;

    public static bool IsPause => _isPause;

    private void Awake()
    {
        _startButton = GetComponent<Button>();
        Time.timeScale = 0;
        _isPause = true;
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
        _isPause = false;
        _adButton.SetActive(false);
        gameObject.SetActive(false);
        _slider.SetActive(true);
        _line.SetActive(false);
        _spawner.enabled = false;
        _spawner.GetComponent<Remover>().enabled = false;
        _observer.Init();
    }
}