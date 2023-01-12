using UnityEngine;
using TMPro;

public class EndBattle : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    
    private NextLevel _nextLevel;

    private string _winTxt = "Win!";
    private string _loseTxt = "Lose...";

    private void Awake()
    {
        _nextLevel = GetComponentInChildren<NextLevel>();
    }

    public void SetPanelInfo(bool isWin)
    {
        _text.text = isWin == true ? _winTxt : _loseTxt;
        _nextLevel.gameObject.SetActive(isWin);
    }
}