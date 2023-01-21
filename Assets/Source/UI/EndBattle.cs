using UnityEngine;
using TMPro;

public class EndBattle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private NextLevel _nextLevel;
    private  bool _isFinished;
    private string _winTxt = "Win!";
    private string _loseTxt = "Lose...";

    public bool IsFinished => _isFinished;

    private void Awake()
    {
        _nextLevel = GetComponentInChildren<NextLevel>();
    }

    public void SetPanelInfo(bool isWin)
    {
        _isFinished = true;
        _text.text = isWin == true ? _winTxt : _loseTxt;

        if(_nextLevel != null)
            _nextLevel.gameObject.SetActive(isWin);
    }
}