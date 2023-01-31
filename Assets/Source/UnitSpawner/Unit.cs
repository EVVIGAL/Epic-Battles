using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _skillSprite;
    [SerializeField] private string _name;
    [SerializeField] private string _skill;
    [SerializeField] private int _cost;

    public Sprite Sprite => _sprite;

    public Sprite SkillSprite => _skillSprite; 

    public string Name => _name;

    public string Skill => _skill;

    public int Cost => _cost;

    public void Remove()
    {
        Destroy(gameObject);
    }
}