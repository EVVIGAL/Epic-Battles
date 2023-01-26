using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Start : MonoBehaviour
{
    [SerializeField] private GameObject _slider;
    [SerializeField] private GameObject _line;
    [SerializeField] private GameObject _infoPanel;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private UnitsObserver _observer;
    [SerializeField] private SkillsController _skillController;
    [SerializeField] private TextMeshProUGUI _text;

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
            _infoPanel.SetActive(false);
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