using UnityEngine.Events;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int _cost;
    [SerializeField] private string _name;

    public UnityAction IsDestroyed;

    private CharacterControllerMovement _character;

    public int Cost => _cost;

    public string Name => _name;

    private void OnEnable()
    {
        _character = GetComponent<CharacterControllerMovement>();
    }

    private void Update()
    {
        if (_character != null)
        {
            if (!_character.enabled)
            {
                this.enabled = false;
                IsDestroyed?.Invoke();
            }
        }
    }

    public void Remove()
    {
        Destroy(gameObject);
    }
}