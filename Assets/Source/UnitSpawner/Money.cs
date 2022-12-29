using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    [SerializeField] private int _amount;

    private TextMeshProUGUI _moneyText;

    public int Amount => _amount;

    private void Awake()
    {
        _moneyText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _moneyText.text = _amount.ToString();
    }

    public void AddMoney(int money)
    {
        if (money > 0)
        {
            _amount += money;
            _moneyText.text = _amount.ToString();
        }
    }

    public void SpendMoney(int money)
    {
        if (money > 0)
        {
            _amount -= money;
            _moneyText.text = _amount.ToString();
        }
    }
}
