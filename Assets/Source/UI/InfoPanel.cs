using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private Image _image;

    private TextMeshProUGUI _text;

    private void Awake()
    {
        _text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Activate(Unit unit)
    {
        gameObject.SetActive(true);
        _text.text = unit.Name + "\n" + unit.Cost + "\n" + unit.Skill;
        _image.overrideSprite = unit.Sprite;
    }
}