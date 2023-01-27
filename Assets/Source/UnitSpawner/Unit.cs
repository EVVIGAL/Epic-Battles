using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _skillSprite;
    [SerializeField] private string _name;
    [SerializeField] private string _skill;
    [SerializeField] private int _cost;

    private uint _health;
    private uint _damage;

    private void Awake()
    {
        _health = GetComponent<Health>().MaxValue;
        _damage = GetComponent<Weapon>().Damage;
    }

    public Sprite Sprite => _sprite;

    public Sprite SkillSprite => _skillSprite; 

    public string Name => _name;

    public uint Health => _health;

    public uint Damage => _damage;

    public string Skill => _skill;

    public int Cost => _cost;

    public void Remove()
    {
        Destroy(gameObject);
    }
}