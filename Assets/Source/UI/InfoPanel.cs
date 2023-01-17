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
        string health = unit.GetComponent<Health>().MaxValue.ToString();
        gameObject.SetActive(true);
        _text.text = unit.Name + "\n" + "Health: " + health + "\n" + "Available skill: " + unit.Skill;
        _image.overrideSprite = unit.Sprite;
    }
}