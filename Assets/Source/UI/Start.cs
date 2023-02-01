using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Start : MonoBehaviour
{
    [SerializeField] private SkillsController _skillController;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private UnitsObserver _observer;
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _line;
    [SerializeField] private Spawner _spawner;

    private Button _startButton;
    private string _coroutineName = "HideAfterWait";
    private static bool _isPause;

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
        if (_observer.TryStart())
        {
            Time.timeScale = 1;
            _isPause = false;
            _slider.SetActive(true);
            _line.SetActive(false);
            _spawner.enabled = false;
            _spawner.GetComponent<Remover>().enabled = false;
            _observer.Init();
            _skillController.CheckUnits();
        }
        else
        {
            _text.gameObject.SetActive(true);
            _text.GetComponent<InfoText>().StartCoroutine(_coroutineName);
        }
    }
}